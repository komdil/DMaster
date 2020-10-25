using OceanAirdrop;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data;

namespace OceanAirdrop
{
    public static class DBHelper
    {
        public static List<DBTableInfo> GetTableInfo(string tableName)
        {
            List<DBTableInfo> list = new List<DBTableInfo>();

            try
            {
                string sql = string.Format("PRAGMA table_info({0});",tableName);

                SQLiteCommand command = new SQLiteCommand(sql, LocalSqllite.m_sqlLiteConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DBTableInfo data = new DBTableInfo();
                    data.m_cid = reader["cid"].ToString();
                    data.m_columnName = reader["name"].ToString();
                    data.m_columnType = reader["type"].ToString();
                    data.m_defaultValue = reader["notnull"].ToString();
                    data.m_notNull = reader["dflt_value"].ToString();
                    data.m_primaryKey = reader["pk"].ToString();

                    list.Add(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        public static List<AppSettingData> GetAppSettings()
        {
            List<AppSettingData> list = new List<AppSettingData>();

            try
            {
                string sql = "SELECT setting, value FROM app_settings";

                SQLiteCommand command = new SQLiteCommand(sql, LocalSqllite.m_sqlLiteConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AppSettingData data = new AppSettingData();
                    data.m_setting = reader["setting"].ToString();
                    data.m_value = reader["value"].ToString();

                    list.Add(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        public static List<TimerType> GetTimerList()
        {
            List<TimerType> list = new List<TimerType>();

            try
            {
                string sql = "SELECT pmo_number, description FROM timer_types";

                SQLiteCommand command = new SQLiteCommand(sql, LocalSqllite.m_sqlLiteConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TimerType data = new TimerType();
                    data.pmo_num = reader["pmo_number"].ToString();
                    data.desc = reader["description"].ToString();

                    list.Add(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        public static string DateToDBDateTime(DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string DateToDBDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static string GenerateInsertTimeRecordSQL(TimerType data)
        {
            StringBuilder sqlStatement = new StringBuilder();

            try
            {
                string startDate        = DateToDBDate(DateTime.Now);
                string startDateTime    = DateToDBDateTime(DateTime.Now);

                // insert statment
                sqlStatement.AppendLine("INSERT OR IGNORE INTO time_sheet ( date, work_start_time, work_end_time, pmo_number ) VALUES ( ");
                sqlStatement.AppendLine(string.Format("'{0}'", startDate));
                sqlStatement.AppendLine(string.Format(",'{0}'", startDateTime));
                sqlStatement.AppendLine(string.Format(",'{0}'", startDateTime));
                sqlStatement.AppendLine(string.Format(",'{0}'", data.pmo_num));
                sqlStatement.AppendLine(");");

                sqlStatement.AppendLine("-- get id from insert");
                sqlStatement.AppendLine("SELECT last_insert_rowid()"); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return sqlStatement.ToString();
        }

        public static string GenerateUpdateTimeRecordSQL(TimerType data, TimeSpan elapsed)
        {
            StringBuilder sqlStatement = new StringBuilder();

            try
            {
                string currentDateTime = DateToDBDateTime(DateTime.Now);

                sqlStatement.AppendLine("UPDATE time_sheet SET ");
                sqlStatement.AppendLine(string.Format("work_end_time = '{0}'", currentDateTime));
                sqlStatement.AppendLine(string.Format(",mins_accrued = '{0}'", elapsed.TotalMinutes));
                sqlStatement.AppendLine(string.Format("WHERE work_id = '{0}'", data.db_id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return sqlStatement.ToString();
        }
    }
}

