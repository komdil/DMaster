
using DMaster.Model;
using DMaster.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
namespace DMaster.ViewModels
{
    public class BaseViewModel: Conductor<object>
    {
        public string Title { get; set; }
        public override string ToString()
        {
        
            return Title;
        }
        public DataProvider DataProvider { get; set; }
        public User User { get; set; }
        Project project;
        public Project Project { get { return project; } set { project = value;
                NotifyOfPropertyChange(nameof(Project)); }
        }
        Period period;
        public Period CurrentPeriod { get { return period; } set { period = value;NotifyOfPropertyChange(nameof(CurrentPeriod)); } }
        public BaseViewModel()
        {
            Load();
        }
        public void Load()
        {
            DataProvider = new DataProvider();
            try
            {
                var auth = DataProvider.GetEntity<Authorize>().Single(a => a.Machine.ProcessorId == Machine.GetProcessorId());
                Project = DataProvider.GetEntity<Project>().OrderByDescending(a => a.Status == Status.InProgress).FirstOrDefault();
                if (Project!=null)
                {
                    CurrentPeriod = Project.Periods.OrderByDescending(d => d.Status == Status.InProgress).OrderByDescending(a => a.From).FirstOrDefault();
                }
                User = auth.User;
            }
            catch (Exception ex)
            {
                string msg = Helper.GetMessage(ex);
                Model.Helpers.Message.ShowErrorMsg(msg);
            }
        }
         ~BaseViewModel()
        {
            DataProvider.Context.Dispose();
        }
    }
}
