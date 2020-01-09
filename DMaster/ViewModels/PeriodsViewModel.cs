using DMaster.Model;
using DMaster.Model.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace DMaster.ViewModels
{
    public class PeriodsViewModel:BaseViewModel
    {
        public ObservableCollection<Period> Periods { get; set; }
        public ObservableCollection<Project> Projects { get; set; }
        public bool CanRemove { get { return SelectedPeriod != null; } }
      
        Period period;
        public Period SelectedPeriod
        {
            get { return period; }
            set
            {
                period = value; NotifyOfPropertyChange(nameof(SelectedPeriod));

                NotifyOfPropertyChange(nameof(RemovePeriod));
            }
        }
        private void Load()
        {
            DataProvider = new DataProvider();
            Periods = new ObservableCollection<Period>(DataProvider.GetEntity<Period>().OrderByDescending(s => s.Status));
            Projects = new ObservableCollection<Project>(DataProvider.GetEntity<Project>());
        }
        public PeriodsViewModel()
        {
            Load();
        }
        public Command Save { get { return new Command(true, new Action(SaveCmd)); } }
        public Command AddPeriod { get { return new Command(true, new Action(AddPeriodCmd)); } }
        public Command RemovePeriod { get { return new Command(CanRemove, new Action(RemovePeriodCmd)); } }
        private void SaveCmd()
        {
            try
            {
                var dataprovider = new DataProvider();  
                var exists_period = dataprovider.GetEntity<Period>().Any(a => a.ProjectId == SelectedPeriod.Project.Id && a.Title==SelectedPeriod.Title && a.Id!=SelectedPeriod.Id);
                if (exists_period)
                {
                    throw new Exception("SelectedProject already has this Period (Title must be diffenrent) ");
                }
                DataProvider.SaveChanges();
                Message.ShowComMsg("Save Complated!");
            }
            catch (Exception ex)
            {
                string msg = Helper.GetMessage(ex);
                Message.ShowErrorMsg("Project is not selected or SelectedProject already has this Period\n"+msg);
            }

        }
        private void AddPeriodCmd()
        {
            var newPeriod = new Period();
            DataProvider.AddEntity(newPeriod);
            Periods.Add(newPeriod);
            SelectedPeriod = newPeriod;
        }
        private void RemovePeriodCmd()
        {
            var Yes = MessageBox.Show("Would you like delete project?\n All Tasks and Periods will be deleted!!!", "Deleting Project", MessageBoxButton.YesNo);
            if (Yes == MessageBoxResult.Yes)
            {
                DataProvider.Remove(SelectedPeriod);
                Periods.Remove(SelectedPeriod);
                DataProvider.SaveChanges();
            }
        }
    }
}
