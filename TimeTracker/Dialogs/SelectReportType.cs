using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker.Dialogs
{
    public partial class SelectReportType : Form
    {
        public SelectReportType()
        {
            InitializeComponent();
        }

        private void SelectReportType_Load(object sender, EventArgs e)
        {

        }

        private void buttonSummaryReport_Click(object sender, EventArgs e)
        {
            ReportSummary dlg = new ReportSummary();
            dlg.Show();

            this.DialogResult = DialogResult.OK;
        }

        private void buttonDetailedReport_Click(object sender, EventArgs e)
        {
            ReportDetailed dlg = new ReportDetailed();
            dlg.Show();

            this.DialogResult = DialogResult.OK;
        }
    }
}
