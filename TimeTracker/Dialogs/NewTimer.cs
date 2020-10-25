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
    public partial class NewTimer : Form
    {
        public string m_pmoNum;
        public string m_desc;

        public NewTimer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            m_pmoNum = textBoxPMONumber.Text;
            m_desc = textBoxDescription.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void NewTimer_Load(object sender, EventArgs e)
        {
            textBoxPMONumber.Text = m_pmoNum;
            textBoxDescription.Text = m_desc;
        }
    }
}
