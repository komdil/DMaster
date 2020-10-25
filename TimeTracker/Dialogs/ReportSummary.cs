using OceanAirdrop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTracker.Data;

namespace TimeTracker.Dialogs
{
    public partial class ReportSummary : Form
    {

        List<string> m_dates = new List<string>();

        DateTime m_monday;

        int prevNextCount = 0;


        public ReportSummary()
        {
            InitializeComponent();
        }

        private void TimeSheetData_Load(object sender, EventArgs e)
        {
            SetupDataGridView(dataGridView1);

            LoadData(DateTime.Now);
        }

        private void SetTitleText()
        {
            this.Text = string.Format("Summary Report: Week Beginning {0}", DBHelper.DateToDBDate(m_monday));
        }

        private void SetWeekText()
        {
            if (prevNextCount < 0)
            {
                labelDescription.Text = string.Format("Previous Week ({0})", prevNextCount);
            }
            if (prevNextCount > 0)
            {
                labelDescription.Text = string.Format("Future Week ({0})", prevNextCount);
            }
            if (prevNextCount == 0)
            {
                labelDescription.Text = "This Week";
            }
        }

        private void LoadData(DateTime dateStart)
        {
            SetWeekText();
           
            SetupDataGridViewHeaders(dateStart);

            SetTitleText();

            dataGridView1.Rows.Clear();

            var timerList = DBHelper.GetTimerList();

            foreach (TimerType timerType in timerList)
            {
                List<string> dayTotals = new List<string>();
                foreach (string date in m_dates)
                {
                    string sql = string.Format("select  ifnull(sum(mins_accrued),0) from time_sheet where date = '{0}' and pmo_number = '{1}'", date, timerType.pmo_num);

                    string result = LocalSqllite.ExecSQLCommandScalar(sql);

                    dayTotals.Add(result);
                }

                AddToDataGridView(timerType.desc, timerType.pmo_num, dayTotals[0], dayTotals[1], dayTotals[2], dayTotals[3], dayTotals[4], dayTotals[5], dayTotals[6], Color.Black);
            }

            AddTotalsRow();

            HighlightCurrentDayColumn();
        }

        private void HighlightCurrentDayColumn()
        {
            try
            {
                int cellIndex = 0;
                string currentDate = DBHelper.DateToDBDate(DateTime.Now);

                // Step 01: First need to find today column with the week.
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {      
                    if (column.HeaderText.Contains(currentDate))
                        break;

                    cellIndex++;
                }

                // Step 01: Now we have the column index we can set the foreground text to red.
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[cellIndex].Style.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AddTotalsRow()
        {
            try
            {
                // Add a totals row.
                List<string> dayTotals = new List<string>();
                foreach (string date in m_dates)
                {
                    string sql = string.Format("select  ifnull(sum(mins_accrued),0) from time_sheet where date = '{0}'", date);

                    string result = LocalSqllite.ExecSQLCommandScalar(sql);

                    dayTotals.Add(result);
                }

                // Add a totals row.
                AddToDataGridView("TOTAL", "N/A", dayTotals[0], dayTotals[1], dayTotals[2], dayTotals[3], dayTotals[4], dayTotals[5], dayTotals[6], Color.Red);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SetupDataGridView(DataGridView dgv)
        {
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            dgv.DefaultCellStyle.BackColor = Color.Empty;
            // dgv.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.AllowUserToAddRows = false;

            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }


        private void SetupDataGridViewHeaders(DateTime startDate)
        {
            try 
	        {
                m_dates.Clear();

                int delta = DayOfWeek.Monday - startDate.DayOfWeek;
                m_monday = startDate.AddDays(delta);

                this.dataGridView1.Columns[2].HeaderText = "Mon " + DBHelper.DateToDBDate(m_monday);

                m_dates.Add(DBHelper.DateToDBDate(m_monday));

                DateTime tues = m_monday.AddDays(1);
                this.dataGridView1.Columns[3].HeaderText = "Tues " + DBHelper.DateToDBDate(tues);
                m_dates.Add(DBHelper.DateToDBDate(tues));

                DateTime weds = tues.AddDays(1);
                this.dataGridView1.Columns[4].HeaderText = "Wed " + DBHelper.DateToDBDate(weds);
                m_dates.Add(DBHelper.DateToDBDate(weds));

                DateTime thurs = weds.AddDays(1);
                this.dataGridView1.Columns[5].HeaderText = "Thurs " + DBHelper.DateToDBDate(thurs);
                m_dates.Add(DBHelper.DateToDBDate(thurs));

                DateTime fri = thurs.AddDays(1);
                this.dataGridView1.Columns[6].HeaderText = "Fri " + DBHelper.DateToDBDate(fri);
                m_dates.Add(DBHelper.DateToDBDate(fri));

                DateTime sat = fri.AddDays(1);
                this.dataGridView1.Columns[7].HeaderText = "Sat " + DBHelper.DateToDBDate(sat);
                m_dates.Add(DBHelper.DateToDBDate(sat));

                DateTime sun = sat.AddDays(1);
                this.dataGridView1.Columns[8].HeaderText = "Sun " + DBHelper.DateToDBDate(sun);
                m_dates.Add(DBHelper.DateToDBDate(sun));
	        }
	        catch (Exception ex)
	        {
                Console.WriteLine(ex.Message);
	        }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddToDataGridView(string desc, string pmo, string mon, string tue, string wed, string thurs, string fri, string sat, string sun, Color rowColour )
        {
            int nNewRow = dataGridView1.Rows.Add();

            int nColCount = 0;

            dataGridView1.Rows[nNewRow].Cells[nColCount].Value = desc;
            dataGridView1.Rows[nNewRow].Cells[nColCount++].Style.ForeColor = rowColour;
                


            dataGridView1.Rows[nNewRow].Cells[nColCount].Value = pmo;
            dataGridView1.Rows[nNewRow].Cells[nColCount++].Style.ForeColor = rowColour;

            SetDataGridViewRow(nNewRow, nColCount++, mon, rowColour );
            SetDataGridViewRow(nNewRow, nColCount++, tue, rowColour);
            SetDataGridViewRow(nNewRow, nColCount++, wed, rowColour);
            SetDataGridViewRow(nNewRow, nColCount++, thurs, rowColour);
            SetDataGridViewRow(nNewRow, nColCount++, fri, rowColour);
            SetDataGridViewRow(nNewRow, nColCount++, sat, rowColour);
            SetDataGridViewRow(nNewRow, nColCount++, sun, rowColour);
        }

        private void SetDataGridViewRow(int nNewRow, int nColCount, string value, Color c)
        {
            try
            {
                dataGridView1.Rows[nNewRow].Cells[nColCount].Tag = value;
                dataGridView1.Rows[nNewRow].Cells[nColCount].Value = TotalMinsToFriendlyTime(value);
                dataGridView1.Rows[nNewRow].Cells[nColCount].Style.ForeColor = c;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void buttonPrevWeek_Click(object sender, EventArgs e)
        {
            prevNextCount--;
            LoadData(m_monday.AddDays(-7));
        }

        private void buttonNextWeek_Click(object sender, EventArgs e)
        {
            prevNextCount++;
            LoadData(m_monday.AddDays(7));
        }

        private void buttonSelectWeek_Click(object sender, EventArgs e)
        {

        }

        private string TotalMinsToFriendlyTime( string totalMins )
        {
            if (totalMins == "")
                totalMins = "0";

            string sqlFriendlyTime = string.Format("SELECT time({0} * 60, 'unixepoch');", totalMins);

            string friendlyTime = LocalSqllite.ExecSQLCommandScalar(sqlFriendlyTime);

            return friendlyTime;
        }

        private void TimeSheetData_Shown(object sender, EventArgs e)
        {
            this.BringToFront();
        }
    }
}

