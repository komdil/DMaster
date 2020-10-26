using Caliburn.Micro;
using DMaster.Model;
using DMaster.Model.Helpers;
using System;
using System.Linq;

namespace DMaster.ViewModels
{
    public class AuthViewModel : Conductor<object>
    {
        MainContext MainContext = Global.MainContext;
        public Command Cancel { get { return new Command(true, new System.Action(CancelCmd)); } }
        public Command LogIn { get { return new Command(true, new System.Action(Login)); } }
        public string UserId { get; set; }
        public string Password { get; set; }

        private void Login()
        {
            var user = MainContext.GetEntities<User>().FirstOrDefault(a => a.Id == UserId && a.Password == Password);
            if (user != null && UserId != "Any")
            {
                var Auth = new Authorize();
                var machine = MainContext.GetEntities<Machine>().FirstOrDefault(a => a.ProcessorId == Machine.GetProcessorId() && a.Name == Environment.MachineName);
                if (machine == null)
                {
                    machine = new Machine();
                    machine.ProcessorId = Machine.GetProcessorId();
                    machine.Name = Environment.MachineName;
                }
                Auth.Machine = machine;
                Auth.User = user;
                MainContext.AddEntity(Auth);
                MainContext.SaveChanges();
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
