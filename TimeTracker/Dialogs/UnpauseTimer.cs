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
    public partial class UnpauseTimer : Form
    {
        public int m_unpauseMins = 15;

        public UnpauseTimer()
        {
            InitializeComponent();
        }

        private void UnpauseTimer_Load(object sender, EventArgs e)
        {
            radioButton15Mins.Checked = true;

        }

        private void radioButton5Mins_CheckedChanged(object sender, EventArgs e)
        {
            m_unpauseMins = 5;
        }

        private void radioButton10Mins_CheckedChanged(object sender, EventArgs e)
        {
            m_unpauseMins = 10;
        }

        private void radioButton15Mins_CheckedChanged(object sender, EventArgs e)
        {
            m_unpauseMins = 15;
        }

        private void radioButtonNever_CheckedChanged(object sender, EventArgs e)
        {
            m_unpauseMins = -1;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (radioButtonCustom.Checked == true )
            {
                m_unpauseMins = Convert.ToInt32(textBoxCustomMins.Text);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void textBoxCustomMins_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxCustomMins.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter numbers only.");
                textBoxCustomMins.Text.Remove(textBoxCustomMins.Text.Length - 1);
            }
        }

        private void radioButtonCustom_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton30Mins_CheckedChanged(object sender, EventArgs e)
        {
            m_unpauseMins = 30;
        }

        private void radioButton60Mins_CheckedChanged(object sender, EventArgs e)
        {
            m_unpauseMins = 60;
        }
    }
}
