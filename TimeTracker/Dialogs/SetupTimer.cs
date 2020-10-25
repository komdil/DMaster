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
    public partial class SetupTimer : Form
    {
        public List<TimerType> m_list = new List<TimerType>();

        public SetupTimer()
        {
            InitializeComponent();
        }

        private void SetupTimer_Load(object sender, EventArgs e)
        {
            PopulateList();
        }

        void PopulateList()
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                NewTimer dlg = new NewTimer();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dlg.m_pmoNum;
                    item.SubItems.Add(dlg.m_desc);

                    listViewTimers.Items.Add(item);

                    string sql = string.Format("INSERT INTO [timer_types] (pmo_number, description) VALUES ('{0}', '{1}')", dlg.m_pmoNum, dlg.m_desc);
                    LocalSqllite.ExecSQLCommand(sql);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewTimers.SelectedItems.Count == 0)
                {
                    MessageBox.Show("You have not selected an item.");
                    return;
                }

                NewTimer dlg = new NewTimer();

                ListViewItem itm = listViewTimers.SelectedItems[0];

                TimerType selected = (TimerType)itm.Tag;

                dlg.m_pmoNum = selected.pmo_num;
                dlg.m_desc = selected.desc;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //itm.Text = dlg.m_pmoNum;
                    //itm.SubItems[0].Text = dlg.m_desc;

                    string sql = string.Format("UPDATE [timer_types] SET description = '{0}' where pmo_number = '{1}'", dlg.m_desc, dlg.m_pmoNum);
                    LocalSqllite.ExecSQLCommand(sql);

                    PopulateList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewTimers.SelectedItems.Count == 0)
                {
                    MessageBox.Show("You have not selected an item.");
                    return;
                }

                ListViewItem itm = listViewTimers.SelectedItems[0];

                TimerType selected = (TimerType)itm.Tag;

                DialogResult result = MessageBox.Show("Are you sure you want to REMOVE this item?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string sql = string.Format("delete from [timer_types] where pmo_number = {0} ", selected.pmo_num);
                    LocalSqllite.ExecSQLCommand(sql);

                    PopulateList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
