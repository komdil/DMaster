using OceanAirdrop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTracker.Data;

namespace TimeTracker.Dialogs
{
    public enum ReportMode { EditMode, DetailReportMode };

    public partial class ReportDetailed : Form
    {
        int prevNextCount = 0;

        DateTime m_now;

        public ReportMode m_mode = ReportMode.DetailReportMode;

        public ReportDetailed()
        {
            InitializeComponent();
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
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.AllowUserToAddRows = false;

            if (m_mode == ReportMode.EditMode)          
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            else
                dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        private void DetailedReport_Load(object sender, EventArgs e)
        {
            SetupDataGridView(dataGridView1);

            if (m_mode == ReportMode.DetailReportMode)
            {
                // hide buttons
                buttonAdd.Hide();
                buttonEdit.Hide();
                buttonDelete.Hide();

                SetupGridLocation();
                SetupPrevButtonLocation();
            }

            m_now = DateTime.Now;

            LoadData(m_now);


        }

        private void SetupPrevButtonLocation()
        {
            if (m_mode == ReportMode.DetailReportMode)
            {
                // take up the full screen
                this.buttonPrevDay.Location = new System.Drawing.Point(12, 236);
                this.buttonPrevDay.Size = new System.Drawing.Size(96, 33);

                this.labelDescription.Location = new System.Drawing.Point(114, 238);
                this.labelDescription.Size = new System.Drawing.Size(535, 31);
            }
            else
            {
                this.buttonPrevDay.Location = new System.Drawing.Point(107, 236);
                this.buttonPrevDay.Size = new System.Drawing.Size(96, 33);

                this.labelDescription.Location = new System.Drawing.Point(209, 238);
                this.labelDescription.Size = new System.Drawing.Size(440, 31);
            }
        }

        private void SetupGridLocation()
        {
            if (m_mode == ReportMode.DetailReportMode)
            {
                // take up the full screen
                this.dataGridView1.Location = new System.Drawing.Point(5, 0);
                this.dataGridView1.Size = new System.Drawing.Size(758, 230);
            }
            else
            {
                this.dataGridView1.Location = new System.Drawing.Point(107, 0);
                this.dataGridView1.Size = new System.Drawing.Size(656, 230);
            }
        }

        private void SetTitleText()
        {
            if (m_mode == ReportMode.DetailReportMode)
            {
                this.Text = string.Format("Detailed Report: {0}", DBHelper.DateToDBDate(m_now));
            }
            else
            {
                this.Text = string.Format("Manual Entry / Edit Mode: {0}", DBHelper.DateToDBDate(m_now));
            }
        }

        private string GenerateSQL(DateTime day)
        {
            string date = DBHelper.DateToDBDate(day);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select");
            sb.AppendLine("a.work_id,");
            sb.AppendLine("a.date,");
            sb.AppendLine("a.work_start_time,");
            sb.AppendLine("a.work_end_time,");
            sb.AppendLine("a.pmo_number,");
            sb.AppendLine("b.description,");
            sb.AppendLine("a.mins_accrued");
            sb.AppendLine("from time_sheet a, timer_types b where ");
            sb.AppendLine("a.pmo_number = b.pmo_number");
            sb.AppendLine(string.Format("and date = '{0}'", date));
            sb.AppendLine("order by work_start_time asc");

            return sb.ToString();
        }

                
        private void LoadData(DateTime dateStart)
        {
            try
            {
                SetTitleText();

                dataGridView1.Rows.Clear();

                string sql = GenerateSQL(dateStart);

                SQLiteCommand command = new SQLiteCommand(sql, LocalSqllite.m_sqlLiteConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TimeSheetDetailData data = new TimeSheetDetailData();
                    data.m_workId = reader["work_id"].ToString();
                    data.m_date = reader["date"].ToString();
                    data.m_workStartTime = reader["work_start_time"].ToString();
                    data.m_workEndTime = reader["work_end_time"].ToString();
                    data.m_PMONumber = reader["pmo_number"].ToString();
                    data.m_desc = reader["description"].ToString();
                    data.m_minsAccrued = reader["mins_accrued"].ToString();

                    AddToDataGridView(data, Color.Black);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            SetWeekText();
        }

        private void AddToDataGridView(TimeSheetDetailData data, Color c)
        {
            try
            {
                int nNewRow = dataGridView1.Rows.Add();

                int nColCount = 0;

                dataGridView1.Rows[nNewRow].Tag = data;

                dataGridView1.Rows[nNewRow].Cells[nColCount].Value = data.m_workId;
                dataGridView1.Rows[nNewRow].Cells[nColCount++].Style.ForeColor = c;

                dataGridView1.Rows[nNewRow].Cells[nColCount].Value = data.m_date;
                dataGridView1.Rows[nNewRow].Cells[nColCount++].Style.ForeColor = c;

                dataGridView1.Rows[nNewRow].Cells[nColCount].Value = data.m_workStartTime;
                dataGridView1.Rows[nNewRow].Cells[nColCount++].Style.ForeColor = c;

                dataGridView1.Rows[nNewRow].Cells[nColCount].Value = data.m_workEndTime;
                dataGridView1.Rows[nNewRow].Cells[nColCount++].Style.ForeColor = c;

                dataGridView1.Rows[nNewRow].Cells[nColCount].Value = data.m_PMONumber;
                dataGridView1.Rows[nNewRow].Cells[nColCount++].Style.ForeColor = c;

                dataGridView1.Rows[nNewRow].Cells[nColCount].Value = data.m_desc;
                dataGridView1.Rows[nNewRow].Cells[nColCount++].Style.ForeColor = c;

                dataGridView1.Rows[nNewRow].Cells[nColCount].Value = TotalMinsToFriendlyTime(data.m_minsAccrued);
                dataGridView1.Rows[nNewRow].Cells[nColCount++].Style.ForeColor = c;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string TotalMinsToFriendlyTime(string totalMins)
        {
            if (totalMins == "")
                totalMins = "0";

            string sqlFriendlyTime = string.Format("SELECT time({0} * 60, 'unixepoch');", totalMins);

            string friendlyTime = LocalSqllite.ExecSQLCommandScalar(sqlFriendlyTime);

            return friendlyTime;
        }


        private void DetailedReport_Shown(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void SetWeekText()
        {
            string day = DBHelper.DateToDBDate(m_now);

            if (prevNextCount < 0)
            {
                labelDescription.Text = string.Format("Previous day: {0} ({1})", day, prevNextCount);
            }
            if (prevNextCount > 0)
            {
                labelDescription.Text = string.Format("Next day: {0} ({1})", day, prevNextCount);
            }
            if (prevNextCount == 0)
            {
                labelDescription.Text = string.Format("Today: {0}", day);
            }
        }

        private void buttonPrevDay_Click(object sender, EventArgs e)
        {
            prevNextCount--;

            m_now = m_now.AddDays(-1);

            LoadData(m_now);
        }

        private void buttonNextDay_Click(object sender, EventArgs e)
        {
            prevNextCount++;

            m_now = m_now.AddDays(1);

            LoadData(m_now);
        }

        int m_rowClicked = -1;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            m_rowClicked = e.RowIndex;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || m_mode == ReportMode.DetailReportMode)
                return;

            var data = (TimeSheetDetailData)dataGridView1.Rows[e.RowIndex].Tag;

            DisplayEditDialog(data, EditTimeRecord.Mode.EditMode);
        }

        private void DisplayEditDialog(TimeSheetDetailData data, EditTimeRecord.Mode mode )
        {
            EditTimeRecord dlg = new EditTimeRecord(data, mode);
            dlg.textBoxTimeAccrued.Text = data.m_minsAccrued;
            dlg.textBoxPMONumber.Text = data.m_PMONumber;
            dlg.textBoxWorkEndTime.Text = data.m_workEndTime;
            dlg.textBoxWorkStartDate.Text = data.m_workStartTime;
            dlg.textBoxDate.Text = data.m_date;
            dlg.textBoxWorkId.Text = data.m_workId;

            if ( dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                LoadData(m_now);
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (m_mode == ReportMode.DetailReportMode)
                return;

            TimeSheetDetailData data = new TimeSheetDetailData();
            data.m_workId = "-1";
            data.m_date = DBHelper.DateToDBDate(DateTime.Now);
            data.m_workStartTime = DBHelper.DateToDBDateTime(DateTime.Now.Subtract(new TimeSpan(0,15,0)));
            data.m_workEndTime = DBHelper.DateToDBDateTime(DateTime.Now);

            DisplayEditDialog(data, EditTimeRecord.Mode.AddMode);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (m_rowClicked < 0 || m_mode == ReportMode.DetailReportMode)
                return;

            var data = (TimeSheetDetailData)dataGridView1.Rows[m_rowClicked].Tag;

            DisplayEditDialog(data, EditTimeRecord.Mode.EditMode);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (m_rowClicked < 0 || m_mode == ReportMode.DetailReportMode)
                return;

            var data = (TimeSheetDetailData)dataGridView1.Rows[m_rowClicked].Tag;

            DisplayEditDialog(data, EditTimeRecord.Mode.DeleteMode);
        }
    }
}
