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
    public partial class AppSettings : Form
    {
        public AppSettings()
        {
            InitializeComponent();
        }

        private void AppSettings_Load(object sender, EventArgs e)
        {
            List<AppSettingData> settingList = DBHelper.GetAppSettings();

            foreach (var setting in settingList)
            {
                if (setting.m_setting == "DBVersion")
                    continue;

                AddToDataGridView(setting);
            }

            SetupDataGridView(this.dataGridView1);
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
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        private void AddToDataGridView(AppSettingData data)
        {
            try
            {
                int nNewRow = dataGridView1.Rows.Add();

                dataGridView1.Rows[nNewRow].Cells[0].Value = data.m_setting;
                dataGridView1.Rows[nNewRow].Cells[0].ReadOnly = true;
                dataGridView1.Rows[nNewRow].Cells[0].Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);

                dataGridView1.Rows[nNewRow].Cells[1].Value = data.m_value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string sql = string.Format("UPDATE app_settings SET value = '{0}' WHERE setting = '{1}'", row.Cells[1].Value, row.Cells[0].Value);
                LocalSqllite.ExecSQLCommand(sql);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
