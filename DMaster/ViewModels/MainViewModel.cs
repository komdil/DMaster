using DMaster.Model;
using DMaster.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using TimeTracker;

namespace DMaster.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Users
        ObservableCollection<User> users;
        public ObservableCollection<User> Users { get { return users; } set { users = value; NotifyOfPropertyChange(nameof(Users)); } }
        public List<CommandViewer> UserResps { get; set; }
        public void AddCommandViewerForSuper()
        {
            CommandViewer commandViewer = new CommandViewer();
            commandViewer.Command = new Command(true, new System.Action(AddNewUser));
            commandViewer.Name = "New User";
            UserResps.Add(commandViewer);

            commandViewer = new CommandViewer();
            commandViewer.Command = new Command(true, new System.Action(MyUsers));
            commandViewer.Name = "My Users";
            UserResps.Add(commandViewer);

            commandViewer = new CommandViewer();
            commandViewer.Command = new Command(true, new System.Action(ProjectsCmd));
            commandViewer.Name = "Projects";
            UserResps.Add(commandViewer);

            commandViewer = new CommandViewer();
            commandViewer.Command = new Command(true, new System.Action(PeriodsCmd));
            commandViewer.Name = "Periods";
            UserResps.Add(commandViewer);

            commandViewer = new CommandViewer();
            commandViewer.Command = new Command(true, new System.Action(TasksCmd));
            commandViewer.Name = "Our Tasks";
            UserResps.Add(commandViewer);

        }
        private void AddResponsibilities()
        {
            UserResps = new List<CommandViewer>();
            CommandViewer commandViewer = new CommandViewer();
            commandViewer.Command = new Command(true, new System.Action(GetInfo));
            commandViewer.Name = "Get Info";
            UserResps.Add(commandViewer);
            if (User.Possession == UserPossession.Super)
            {
                AddCommandViewerForSuper();
            }
            commandViewer = new CommandViewer();
            commandViewer.Command = new Command(true, new System.Action(LogOut));
            commandViewer.Name = "Log Out";
            UserResps.Add(commandViewer);
        }
        private void MyUsers()
        {
            Helper.OpenWindow<MyUsersViewModel>();
        }
        private void TasksCmd()
        {
            var res = Helper.GetWindow<TaskViewModel>(false);
            res.Deactivated += Res_Deactivated;
            void Res_Deactivated(object sender, Caliburn.Micro.DeactivationEventArgs e)
            {
                NotifyTasks();
            }
        }


        #endregion

        #region ProjectsAndPrediods
        ObservableCollection<Project> projects;
        public ObservableCollection<Project> Projects { get { return projects; } set { projects = value; NotifyOfPropertyChange(nameof(Projects)); } }
        private void ProjectsCmd()
        {
            Helper.OpenWindow<ProjectViewModel>();
        }

        #endregion

        #region TopButtons

        public Command Search { get { return new Command(true, new Action(SearchCmd)); } }
        public bool IsSearch { get; set; }
        private void SearchCmd()
        {
            IsSearch = true;
            NotifyTasks();
            IsSearch = false;
        }

        string text;
        public string TextSearch { get { return text; } set { text = value; NotifyOfPropertyChange(nameof(TextSearch)); } }

        #region NewTask
        public Command NewTask { get { return new Command(true, new System.Action(NewTaskCmd)); } }

        private void NewTaskCmd()
        {
            var window = Helper.GetWindow<TaskViewModel>(true);
            window.Deactivated += Window_Deactivated;
            void Window_Deactivated(object sender, Caliburn.Micro.DeactivationEventArgs e)
            {
                NotifyTasks();
            }
        }
        #endregion

        #region RefResh
        public Command RefreshBtn { get { return new Command(true, new System.Action(RefreshCmd)); } }
        private void RefreshCmd()
        {
            LoadData();
            NotifyTasks();
        }
        #endregion

        #region RightSide
        private void LogOut()
        {
            var auth = User.Authorizes.Single(a => a.Machine.ProcessorId == Machine.GetProcessorId());
            MainContext.Remove(auth);
            MainContext.SaveChanges();
            Helper.OpenWindow<AuthViewModel>();
            TryClose();
        }
        private void AddNewUser()
        {
            Helper.OpenWindow<AddUserViewModel>();
        }
        private void GetInfo()
        {
            Helper.OpenWindow<InfoViewModel>();
        }
        private void PeriodsCmd()
        {
            Helper.OpenWindow<PeriodsViewModel>();
        }
        #endregion

        #endregion

        #region Tasks

        #region List Of Tasks

        public bool CheckTaskBySearch(DTask task)
        {
            if (string.IsNullOrEmpty(TextSearch))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool IsNumeric(string value)
        {
            try
            {
                int a = int.Parse(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ObservableCollection<DTask> GetTasks(Status status, string Title = null, int Id = 0, User user = null)
        {
            if (user == null || user.Id == "All")
            {
                if (CurrentPeriod != null)
                {
                    if (Title != null)
                    {
                        return new ObservableCollection<DTask>(CurrentPeriod.Tasks.Where(a => a.Status == status && a.Title.ToLower().Contains(Title.ToLower())).OrderByDescending(d => d.PeriodId == CurrentPeriod.Id));
                    }
                    else if (Id != 0)
                    {
                        return new ObservableCollection<DTask>(CurrentPeriod.Tasks.Where(a => a.Status == status && a.Id == Id).OrderByDescending(d => d.PeriodId == CurrentPeriod.Id));
                    }
                    else
                    {
                        return new ObservableCollection<DTask>(CurrentPeriod.Tasks.Where(a => a.Status == status).OrderByDescending(d => d.PeriodId == CurrentPeriod.Id));
                    }
                }
                else
                {
                    return new ObservableCollection<DTask>();
                }
            }
            else
            {
                if (Title != null)
                {
                    return new ObservableCollection<DTask>(user.Tasks.Where(a => a.Status == status && a.Title.ToLower().Contains(Title.ToLower())).OrderByDescending(d => d.PeriodId == CurrentPeriod.Id));
                }
                else if (Id != 0)
                {
                    return new ObservableCollection<DTask>(user.Tasks.Where(a => a.Status == status && a.Id == Id).OrderByDescending(d => d.PeriodId == CurrentPeriod.Id));
                }
                else
                {
                    return new ObservableCollection<DTask>(user.Tasks.Where(a => a.Status == status).OrderByDescending(d => d.PeriodId == CurrentPeriod.Id));
                }
            }
        }
        public ObservableCollection<DTask> NotStarted
        {
            get
            {
                if (IsSearch)
                {

                    if (IsNumeric(TextSearch))
                    {
                        return GetTasks(Status.NotStarted, user: SelectedUser, Id: int.Parse(TextSearch));
                    }
                    else
                    {
                        return GetTasks(Status.NotStarted, user: SelectedUser, Title: TextSearch);
                    }
                }
                else
                {
                    return GetTasks(Status.NotStarted, user: SelectedUser);
                }

            }
        }
        public ObservableCollection<DTask> InProgress
        {
            get
            {
                if (IsSearch)
                {

                    if (IsNumeric(TextSearch))
                    {
                        return GetTasks(Status.InProgress, user: SelectedUser, Id: int.Parse(TextSearch));
                    }
                    else
                    {
                        return GetTasks(Status.InProgress, user: SelectedUser, Title: TextSearch);
                    }

                }
                else
                {
                    return GetTasks(Status.InProgress, user: SelectedUser);

                }
            }
        }
        public ObservableCollection<DTask> Done
        {
            get
            {
                if (IsSearch)
                {

                    if (IsNumeric(TextSearch))
                    {
                        return GetTasks(Status.Done, user: SelectedUser, Id: int.Parse(TextSearch));
                    }
                    else
                    {
                        return GetTasks(Status.Done, user: SelectedUser, Title: TextSearch);
                    }

                }
                else
                {
                    return GetTasks(Status.Done, user: SelectedUser);

                }
            }
        }

        #endregion

        DTask selected_inpr;
        public DTask SelectedInProgressTask { get { return selected_inpr; } set { selected_inpr = value; NotifyOfPropertyChange(nameof(SelectedInProgressTask)); } }
        DTask selected_nots;
        public DTask SelectedNotStartedTask { get { return selected_nots; } set { selected_nots = value; NotifyOfPropertyChange(nameof(SelectedNotStartedTask)); } }
        DTask selected_done;
        public DTask SelectedDoneTask { get { return selected_done; } set { selected_done = value; NotifyOfPropertyChange(nameof(SelectedDoneTask)); } }

        private void NotifyTasks()
        {
            NotifyOfPropertyChange(nameof(NotStarted));
            NotifyOfPropertyChange(nameof(InProgress));
            NotifyOfPropertyChange(nameof(Done));
        }

        #region Commands

        #region NotStarted
        public Command DeleteNotStartedTask { get { return new Command(true, new Action(DeleteNotStartedCmd)); } }

        private void DeleteNotStartedCmd()
        {
            var request = MessageBox.Show("Would you like delete this task?", "Deleting task", MessageBoxButton.YesNo);
            if (request == MessageBoxResult.Yes)
            {
                MainContext.Remove(SelectedNotStartedTask);
                MainContext.SaveChanges();
                NotifyTasks();
            }

        }

        public Command MakeInProgressNotStarted { get { return new Command(true, new Action(MakeInProgressNotStartedCmd)); } }

        private void MakeInProgressNotStartedCmd()
        {
            var request = MessageBox.Show("Would you like change status of this task?", "Making InProgress task", MessageBoxButton.YesNo);
            if (request == MessageBoxResult.Yes)
            {
                SelectedNotStartedTask.Status = Status.InProgress;
                MainContext.SaveChanges();
                NotifyTasks();

            }
        }

        public Command MakeDoneNotStarted { get { return new Command(true, new Action(MakeDoneNotStartedCmd)); } }

        private void MakeDoneNotStartedCmd()
        {
            var request = MessageBox.Show("Would you like change status of this task?", "Making Done task", MessageBoxButton.YesNo);
            if (request == MessageBoxResult.Yes)
            {
                SelectedNotStartedTask.Status = Status.Done;
                MainContext.SaveChanges();
                NotifyTasks();

            }

        }
        public Command ShowNotStartedTaskInfo { get { return new Command(true, new Action(ShowNotStartedTaskInfoCmd)); } }

        private void ShowNotStartedTaskInfoCmd()
        {
            Helper.GetWindow<TaskInfoViewModel>(SelectedNotStartedTask);
        }

        public Command NotStartedCopyTaskTitle { get { return new Command(true, new Action(() => CopyTaskTitleMethod(SelectedNotStartedTask))); } }
        public Command InProgressCopyTaskTitle { get { return new Command(true, new Action(() => CopyTaskTitleMethod(SelectedInProgressTask))); } }
        public Command DoneCopyTaskTitle { get { return new Command(true, new Action(() => CopyTaskTitleMethod(SelectedDoneTask))); } }

        void CopyTaskTitleMethod(DTask dTask)
        {
            Clipboard.SetText(dTask?.CopyTaskLink());
        }


        public Command NotStartedStartTimer { get { return new Command(true, new Action(() => StartTimer(SelectedNotStartedTask))); } }
        public Command InProgressStartTimer { get { return new Command(true, new Action(() => StartTimer(SelectedInProgressTask))); } }
        public Command DoneStartTimer { get { return new Command(true, new Action(() => StartTimer(SelectedDoneTask))); } }

        void StartTimer(DTask dTask)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            // System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            MainForm mainForm = new MainForm(dTask.GetTimerType());
            System.Windows.Forms.Application.Run(mainForm);
        }

        public Command ShowNotStartedTask { get { return new Command(true, new Action(ShowNotStartedTaskCmd)); } }

        private void ShowNotStartedTaskCmd()
        {
            Helper.GetWindow<TaskViewModel>(SelectedNotStartedTask);
        }
        #endregion

        #region InProgress
        public Command DeleteInProgressTask { get { return new Command(true, new Action(DeleteInProgressTaskCmd)); } }

        private void DeleteInProgressTaskCmd()
        {
            var request = MessageBox.Show("Would you like delete this task?", "Deleting task", MessageBoxButton.YesNo);
            if (request == MessageBoxResult.Yes)
            {
                MainContext.Remove(SelectedInProgressTask);
                MainContext.SaveChanges();
                NotifyTasks();
            }

        }

        public Command MakeNotStartedInProgress { get { return new Command(true, new Action(MakeNotStartedInProgressCmd)); } }

        private void MakeNotStartedInProgressCmd()
        {
            var request = MessageBox.Show("Would you like change status of this task?", "Making Not Started task", MessageBoxButton.YesNo);
            if (request == MessageBoxResult.Yes)
            {
                SelectedInProgressTask.Status = Status.NotStarted;
                MainContext.SaveChanges();
                NotifyTasks();

            }
        }

        public Command MakeDoneInProgress { get { return new Command(true, new Action(MakeDoneInProgressCmd)); } }

        private void MakeDoneInProgressCmd()
        {
            var request = MessageBox.Show("Would you like change status of this task?", "Making Done task", MessageBoxButton.YesNo);
            if (request == MessageBoxResult.Yes)
            {
                SelectedInProgressTask.Status = Status.Done;
                MainContext.SaveChanges();
                NotifyTasks();

            }

        }
        public Command ShowInProgressTaskInfo { get { return new Command(true, new Action(ShowInProgressTaskInfoCmd)); } }

        private void ShowInProgressTaskInfoCmd()
        {
            Helper.GetWindow<TaskInfoViewModel>(SelectedInProgressTask);
        }

        public Command ShowInProgressTask { get { return new Command(true, new Action(ShowInProgressTaskCmd)); } }

        private void ShowInProgressTaskCmd()
        {
            Helper.GetWindow<TaskViewModel>(SelectedInProgressTask);
        }
        #endregion

        #region Done
        public Command DeleteDoneTask { get { return new Command(true, new Action(DeleteDoneCmd)); } }

        private void DeleteDoneCmd()
        {
            var request = MessageBox.Show("Would you like delete this task?", "Deleting task", MessageBoxButton.YesNo);
            if (request == MessageBoxResult.Yes)
            {
                MainContext.Remove(SelectedDoneTask);
                MainContext.SaveChanges();
                NotifyTasks();
            }

        }

        public Command MakeInProgressDone { get { return new Command(true, new Action(MakeInProgressDoneCmd)); } }

        private void MakeInProgressDoneCmd()
        {
            var request = MessageBox.Show("Would you like change status of this task?", "Making InProgress task", MessageBoxButton.YesNo);
            if (request == MessageBoxResult.Yes)
            {
                SelectedDoneTask.Status = Status.InProgress;
                MainContext.SaveChanges();
                NotifyTasks();

            }
        }

        public Command MakeNotStartedDone { get { return new Command(true, new Action(MakeNotStartedDoneCmd)); } }

        private void MakeNotStartedDoneCmd()
        {
            var request = MessageBox.Show("Would you like change status of this task?", "Making Done task", MessageBoxButton.YesNo);
            if (request == MessageBoxResult.Yes)
            {
                SelectedDoneTask.Status = Status.NotStarted;
                MainContext.SaveChanges();
                NotifyTasks();

            }

        }
        public Command ShowDoneTaskInfo { get { return new Command(true, new Action(ShowDoneTaskInfoCmd)); } }

        private void ShowDoneTaskInfoCmd()
        {
            Helper.GetWindow<TaskInfoViewModel>(SelectedDoneTask);
        }


        public Command ShowDoneTask { get { return new Command(true, new Action(ShowDoneTaskCmd)); } }

        private void ShowDoneTaskCmd()
        {
            Helper.GetWindow<TaskViewModel>(SelectedDoneTask);
        }
        #endregion

        #endregion




        #endregion

        #region SelectedUser
        User user;
        public User SelectedUser
        {
            get
            {

                if (user == null)
                {
                    return new User { Id = "All" };
                }
                else
                {
                    return user;
                }
            }
            set { user = value; NotiFySelectedUser(); }
        }
        private void NotiFySelectedUser()
        {
            NotifyOfPropertyChange(nameof(User));
            NotifyTasks();
        }
        #endregion

        public void LoadData()
        {
            base.Load();
            Users = new ObservableCollection<User>(MainContext.GetEntities<User>());
            Projects = new ObservableCollection<Project>(MainContext.GetEntities<Project>());
            NotifyTasks();
        }
        public MainViewModel()
        {
            AddResponsibilities();
            LoadData();
            PropertyChanged += MainViewModel_PropertyChanged;

        }

        public Command ShowAllTasks { get { return new Command(true, new Action(ShowAllTasksCmd)); } }

        private void ShowAllTasksCmd()
        {
            SelectedUser = null;
        }

        private void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CurrentPeriod))
            {
                NotifyTasks();
            }
        }
    }

}
