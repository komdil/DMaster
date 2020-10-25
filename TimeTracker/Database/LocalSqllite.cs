using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace OceanAirdrop
{
    public static class LocalSqllite
    {
        public static string m_dbName = "TimeTracker.db";
        public static SQLiteConnection m_sqlLiteConnection;

        // Creates a connection with our database file.
        public static void ConnectToDatabase()
        {
            try
            {
                m_sqlLiteConnection = new SQLiteConnection(string.Format("Data Source={0};Version=3;", m_dbName));
                m_sqlLiteConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool ExecSQLCommand(string sql)
        {
            bool bSuccess = false;
            try
            {
                SQLiteCommand command = new SQLiteCommand(sql, m_sqlLiteConnection);
                command.ExecuteNonQuery();
                bSuccess = true;
            }
            catch (Exception ex)
            {
                bSuccess = false;
                Console.WriteLine(string.Format("{0}: {1}", ex.Message, sql));
            }

            return bSuccess;
        }

        public static string ExecSQLCommandScalar(string sql)
        {
            string retVal = "";
            try
            {
                SQLiteCommand command = new SQLiteCommand(sql, m_sqlLiteConnection);
                var value = command.ExecuteScalar();
                retVal = value != null ? value.ToString() : "";
            }
            catch (Exception ex)
            {
                Console.WriteLine( string.Format("{0}: {1}", ex.Message, sql));
            }

            return retVal;
        }

        public static string GetAppLocation()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static string GetDBLocation()
        {
            return AppDomain.CurrentDomain.BaseDirectory + m_dbName;
        }

        // Creates an empty database file
        public static void CreateNewSQLLiteDatabase()
        {
            string dbLocation = GetDBLocation();

            FileInfo fi = new FileInfo(dbLocation);
            if (fi.Exists == false)
            {
                SQLiteConnection.CreateFile(dbLocation);

                ConnectToDatabase();
            }
            else
                ConnectToDatabase();

            // Now create schema
            CreateSQLLiteSchema();
            UpgradeDatabase();
        }

        public static bool TableExists( string tableName )
        {
            bool bTableExists = false;

            string sql = string.Format("SELECT name FROM sqlite_master WHERE type='table' AND name='{0}';", tableName);

            string result = ExecSQLCommandScalar(sql);

            if (string.IsNullOrEmpty(result) == false)
                bTableExists = true;

            return bTableExists;
        }

        public static void CreateSQLLiteSchema()
        {
            try
            {
               if ( TableExists( "timer_types" ) == false )
               {
                   StringBuilder timeTypesTable = new StringBuilder();
                   timeTypesTable.Append("create table timer_types ( ");
                   timeTypesTable.Append("pmo_number integer primary key, ");
                   timeTypesTable.Append("description text); ");

                   ExecSQLCommand(timeTypesTable.ToString());
               }

               CreateTimeSheetTable();
               CreateAppSettingsTable();

               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void CreateAppSettingsTable()
        {
            if (TableExists("app_settings") == false)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("create table app_settings ( ");
                sb.Append("setting text primary key , ");
                sb.Append("value text); ");

                ExecSQLCommand(sb.ToString());


                ExecSQLCommand("INSERT INTO app_settings ( setting, value ) VALUES ( 'DBVersion', '1' )");
                ExecSQLCommand("INSERT INTO app_settings ( setting, value ) VALUES ( 'UserName', 'Joe Bloggs' )");
                ExecSQLCommand("INSERT INTO app_settings ( setting, value ) VALUES ( 'DefaultTimer', '12345' )");
                ExecSQLCommand("INSERT INTO app_settings ( setting, value ) VALUES ( 'WorkingDayHours', '7' )");
                ExecSQLCommand("INSERT INTO app_settings ( setting, value ) VALUES ( 'WorkingDayMins', '30' )");
            }
        }

        private static void CreateTimeSheetTable()
        {
            if (TableExists("time_sheet") == false)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("create table time_sheet ( ");
                sb.Append("work_id integer primary key autoincrement, ");
                sb.Append("date text, ");
                sb.Append("work_start_time text, ");
                sb.Append("work_end_time text, ");
                sb.Append("pmo_number integer, ");
                sb.Append("mins_accrued real); ");

                ExecSQLCommand(sb.ToString());
            }
        }

        public static void UpgradeDatabase()
        {
            var tableColumns = DBHelper.GetTableInfo("time_sheet");

            foreach( var col in tableColumns)
            {
                if ( col.m_columnName == "mins_accrued" && col.m_columnType == "integer" )
                {
                    // we need to upgrade database table from integer to real!

                    // Step 00: First backup the database file
                    string dbBackup = string.Format("{0}TimeTracker.db.{1}.bak", GetAppLocation(), DBHelper.DateToDBDate(DateTime.Now));
                    string currentDB = GetDBLocation();
                    File.Copy(currentDB, dbBackup, true);

                    // Step 01: Rename Exisitng table
                    ExecSQLCommand("ALTER TABLE time_sheet RENAME TO time_sheet_bak;");

                    // Step 02: Create New table
                    CreateTimeSheetTable();

                    // Step 03: Copy data fom old table to new table
                    ExecSQLCommand("INSERT INTO time_sheet ( date, work_start_time, work_end_time, pmo_number, mins_accrued ) SELECT date, work_start_time, work_end_time, pmo_number, mins_accrued FROM time_sheet_bak;");

                    // Step 04: drop old table
                    ExecSQLCommand("DROP TABLE time_sheet_bak;");
                }
            }
        }
    }
}
