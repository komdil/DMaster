using Caliburn.Micro;
using DMaster.Model;
using DMaster.Model.Helpers;
using DMaster.Views;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DMaster.ViewModels
{
    public class AuthViewModel : Conductor<object>
    {
        DataProvider DataProvider = new DataProvider();
        public Command Cancel { get { return new Command(true, new System.Action(CancelCmd)); } }
        public Command LogIn { get { return new Command(true, new System.Action(Login)); } }
        public string UserId { get; set; }
        public string Password { get; set; }

        private void Login()
        {
            var user = DataProvider.GetEntity<User>().FirstOrDefault(a => a.Id == UserId && a.Password == Password);
            if (user != null && UserId != "Any")
            {
                var Auth = new Authorize();
                var machine = DataProvider.GetEntity<Machine>().FirstOrDefault(a => a.ProcessorId == Machine.GetProcessorId() && a.Name == Environment.MachineName);
                if (machine == null)
                {
                    machine = new Machine();
                    machine.ProcessorId = Machine.GetProcessorId();
                    machine.Name = Environment.MachineName;
                }
                Auth.Machine = machine;
                Auth.User = user;
                DataProvider.AddEntity(Auth);
                DataProvider.SaveChanges();
                Helper.OpenWindow<MainViewModel>();
                TryClose();
            }
            else
            {
                Model.Helpers.Message.ShowErrorMsg("Incorrect login or password");
            }
        }
        private void CancelCmd()
        {
            TryClose();
        }
    }
}
