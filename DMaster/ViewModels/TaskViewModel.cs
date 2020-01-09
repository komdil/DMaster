using Caliburn.Micro;
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
    public class TaskViewModel:BaseViewModel
    {
   
        public ObservableCollection<Status> Statuses { get; set; } = new ObservableCollection<Status>();
        public ObservableCollection<Weight> Weights { get; set; } = new ObservableCollection<Weight>();
        public ObservableCollection<DTask> Tasks { get; set; }

        CommentViewModel commentView;
        public CommentViewModel CommentVM { get { return commentView; } set { commentView = value;NotifyOfPropertyChange(nameof(CommentVM)); } }

        public ObservableCollection<Period> Periods { get; set; }
        DTask selected;
        public DTask SelectedTask { get { return selected; } set { selected = value;Notify(); } }
        private void Notify()
        {
            NotifyOfPropertyChange(nameof(SelectedTask));
            NotifyOfPropertyChange(nameof(RemoveTask));
            ActiveItem= new CommentViewModel(SelectedTask);
        }

        public ObservableCollection<User> Users { get; set; }
      
        public TaskViewModel(bool create_new_task=false)
        {
            Users = DataProvider.GetEntity<User>();
            Periods = DataProvider.GetEntity<Period>();
            Tasks = DataProvider.GetEntity<DTask>();
            Statuses.Add(Status.NotStarted);
            Statuses.Add(Status.InProgress);
            Statuses.Add(Status.Done);

            Weights.Add(Weight.Low);
            Weights.Add(Weight.Big);
            Weights.Add(Weight.High);

            if (create_new_task)
            {
                AddTaskCmd();
            }
        }

        public TaskViewModel(DTask task)
        {
            Users = DataProvider.GetEntity<User>();
            Periods = DataProvider.GetEntity<Period>();
            Tasks = DataProvider.GetEntity<DTask>();
            Statuses.Add(Status.NotStarted);
            Statuses.Add(Status.InProgress);
            Statuses.Add(Status.Done);

            Weights.Add(Weight.Low);
            Weights.Add(Weight.Big);
            Weights.Add(Weight.High);
            SelectedTask = DataProvider.GetEntity<DTask>().Single(a=>a.Id== task.Id);
         
        }
        #region Commands

        public Command Save { get { return new Command(true, new System.Action(SaveCmd)); } }

        private void SaveCmd()
        {
            try
            {
                var dataprovider = new DataProvider();
                var exists = false;

                try
                {
                    exists = dataprovider.GetEntity<DTask>().Any(t => t.PeriodId == SelectedTask.Period.Id &&
                                    t.Period.ProjectId == SelectedTask.Period.Project.Id && t.Title == SelectedTask.Title && t.Id != SelectedTask.Id);
                }
                catch
                {

                } 
                if (exists)
                {
                    throw new Exception("This Task is Already exists! Change title of Task!");
                }
                DataProvider.SaveChanges();
                Model.Helpers.Message.ShowComMsg("Save Complated!");
            }
            catch (Exception ex)
            {
                string msg = Helper.GetMessage(ex);
                Model.Helpers.Message.ShowErrorMsg(msg);
            }
        }
        public Command AddTask { get { return new Command(true, new System.Action(AddTaskCmd)); } }

        private void AddTaskCmd()
        {
            try
            {
                var newTask = new DTask();
                DataProvider.AddEntity(newTask);
                Tasks.Add(newTask);
                SelectedTask= newTask;
                SelectedTask.Assignee = User;
                SelectedTask.CreatedBy = User;
                SelectedTask.Validator = User;
                SelectedTask.Period = CurrentPeriod;
                SaveCmd();
                NotifyOfPropertyChange(nameof(SelectedTask));
            }
            catch (Exception ex)
            {
                string msg = Helper.GetMessage(ex);
               // Message.ShowErrorMsg("This Task is already exists! Title must be unique!\n" + msg);
            }
        }

        public Command RemoveTask { get { return new Command(CanRemove, new System.Action(RemoveTaskCmd)); } }
        public bool CanRemove { get { return SelectedTask != null ; } }
        private void RemoveTaskCmd()
        {
            var Yes = MessageBox.Show("Would you like delete Task?", "Deleting Task", MessageBoxButton.YesNo);
            if (Yes == MessageBoxResult.Yes)
            {
                DataProvider.Remove(SelectedTask);
                Tasks.Remove(SelectedTask);
                DataProvider.SaveChanges();
            }
        }
        #endregion
    }
}
