using DMaster.Model;
using DMaster.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DMaster.ViewModels
{
    public class ProjectViewModel:BaseViewModel
    {
        public ObservableCollection<Status> Statuses { get; set; } = new ObservableCollection<Status>();
        public ObservableCollection<Project> Projects { get; set; }
        bool canremove = true;
        public bool CanRemove { get { return SelectedProject != null && canremove; } }

        Project project;
        public Project SelectedProject
        {
            get { return project; }
            set
            {
                project = value; NotifyOfPropertyChange(nameof(SelectedProject));
                NotifyOfPropertyChange(nameof(RemoveProject));
            }
        }
        private void Load()
        {
            DataProvider = new DataProvider();
            Projects = new ObservableCollection<Project>(DataProvider.GetEntity<Project>().OrderByDescending(s => s.Status == Status.InProgress));
        }
        public ProjectViewModel()
        {
            Load();
            Statuses.Add(Status.NotStarted);
            Statuses.Add(Status.InProgress);
            Statuses.Add(Status.Done);
        }
        public Command Save { get { return new Command(true, new Action(SaveCmd)); } }
        public Command AddProject { get { return new Command(true, new Action(AddProjectCmd)); } }
        public Command RemoveProject { get { return new Command(CanRemove, new Action(RemoveProjectCmd)); } }
        private void SaveCmd()
        {
            try
            {
                DataProvider.SaveChanges();
                Message.ShowComMsg("Save Complated!");
            }
            catch (Exception ex)
            {
                string msg = Helper.GetMessage(ex);
                Message.ShowErrorMsg("Name must be unique!\n" + msg);
            }
           
        }
        private void AddProjectCmd()
        {
            try
            {
                var newProject = new Project();
                DataProvider.AddEntity(newProject);
                Projects.Add(newProject);
                SelectedProject = newProject;
                DataProvider.SaveChanges();
            }
            catch (Exception ex)
            {
              //  string msg = Helper.GetMessage(ex);
               // Message.ShowErrorMsg("Name must be unique!\n"+msg);
            }
          
        }
        private void RemoveProjectCmd()
        {
            var Yes = MessageBox.Show("Would you like delete project?\n All Tasks and Periods will be deleted!!!", "Deleting Project", MessageBoxButton.YesNo);
            if (Yes==MessageBoxResult.Yes)
            {
                DataProvider.Remove(SelectedProject);
                Projects.Remove(SelectedProject);
                DataProvider.SaveChanges();
            }
        }
        private bool Validate()
        {
            return true;
        }
        
    }
}
