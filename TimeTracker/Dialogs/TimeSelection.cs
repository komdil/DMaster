using OceanAirdrop;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TimeTracker.Data;

namespace TimeTracker.Dialogs
{
    public partial class TimeSelection : Form
    {
        public List<TimerType> m_list = new List<TimerType>();

        public TimerType m_selected = null;

        public TimeSelection()
        {
            InitializeComponent();
        }

        private void TimeSelection_Load(object sender, EventArgs e)
        {
            PopulateList();
        }

        void PopulateList()
        {
            m_list.Clear();
            m_list = DBHelper.GetTimerList();

            listViewTimers.Items.Clear();

            foreach (TimerType data in m_list)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = data;
                item.Text = data.pmo_num;
                item.SubItems.Add(data.desc);

                listViewTimers.Items.Add(item);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (listViewTimers.SelectedItems.Count == 0)
            {
                MessageBox.Show("You have not selected an item.");

                return;
            }

            ListViewItem itm = listViewTimers.SelectedItems[0];

            m_selected = (TimerType)itm.Tag;

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
