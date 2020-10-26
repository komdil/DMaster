using DMaster.Model;
using DMaster.Model.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace DMaster.ViewModels
{
    public class PeriodsViewModel : BaseViewModel
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
        void LoadPeriods()
        {
            Periods = new ObservableCollection<Period>(MainContext.GetEntities<Period>().OrderByDescending(s => s.Status));
            Projects = new ObservableCollection<Project>(MainContext.GetEntities<Project>());
        }
        public PeriodsViewModel()
        {
            LoadPeriods();
        }
        public Command Save { get { return new Command(true, new Action(SaveCmd)); } }
        public Command AddPeriod { get { return new Command(true, new Action(AddPeriodCmd)); } }
        public Command RemovePeriod { get { return new Command(CanRemove, new Action(RemovePeriodCmd)); } }

        private void SaveCmd()
        {
            try
            {
                var exists_period = MainContext.GetEntities<Period>().Any(a => a.ProjectId == SelectedPeriod.Project.Id && a.Title == SelectedPeriod.Title && a.Id != SelectedPeriod.Id);
                if (exists_period)
                {
                    throw new Exception("SelectedProject already has this Period (Title must be diffenrent) ");
                }
                MainContext.SaveChanges();
                Message.ShowComMsg("Save Complated!");
            }
            catch (Exception ex)
            {
                string msg = Helper.GetMessage(ex);
                Message.ShowErrorMsg("Project is not selected or SelectedProject already has this Period\n" + msg);
            }

        }
        private void AddPeriodCmd()
        {
            var newPeriod = new Period();
            MainContext.AddEntity(newPeriod);
            Periods.Add(newPeriod);
            SelectedPeriod = newPeriod;
        }
        private void RemovePeriodCmd()
        {
            var Yes = MessageBox.Show("Would you like delete project?\n All Tasks and Periods will be deleted!!!", "Deleting Project", MessageBoxButton.YesNo);
            if (Yes == MessageBoxResult.Yes)
            {
                MainContext.Remove(SelectedPeriod);
                Periods.Remove(SelectedPeriod);
                MainContext.SaveChanges();
            }
        }
    }
}
