using DMaster.Model;
using DMaster.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMaster.ViewModels
{
    class AddUserViewModel:BaseViewModel
    {
        public bool CanAdd { get { return !string.IsNullOrEmpty(UserId) && !string.IsNullOrEmpty(Password); } }
        private string userid;
        public string UserId { get { return userid; } set { userid = value;Notify(); } }
        private string password;
        public string Password { get { return password; } set { password = value; Notify(); } }
        public UserPossession Possession { get; set; }
        public List<UserPossession> Possessions { get; set; }
        public void Notify()
        {
            NotifyOfPropertyChange(nameof(UserId));
            NotifyOfPropertyChange(nameof(CanAdd));
            NotifyOfPropertyChange(nameof(Password));
            NotifyOfPropertyChange(nameof(Add));
        }
        public AddUserViewModel()
        {
            Title = "Add New User";
            Possessions = new List<UserPossession>();
            Possessions.Add(UserPossession.Expert);
            Possessions.Add(UserPossession.Junior);
            Possessions.Add(UserPossession.Middle);
            Possessions.Add(UserPossession.Super);
        }
        public Command Cancel { get { return new Command(true, new Action(CancelCmd)); } }

        private void CancelCmd()
        {
            TryClose();
        }
        public Command Add { get { return new Command(CanAdd, new Action(AddCmd)); } }
        private void AddCmd()
        {
           if( !DataProvider.GetEntity<User>().Any(a => a.Id == UserId))
            {
                User user = new User
                {
                    Id=UserId,
                    Password=Password,
                    Possession=Possession
                };
                DataProvider.AddEntity(user);
                DataProvider.SaveChanges();
                Message.ShowComMsg("You added new User");
                TryClose();
            }
        }
    }
}
