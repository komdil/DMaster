using DMaster.Model;
using DMaster.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMaster.ViewModels
{
    public class MyUsersViewModel:BaseViewModel
    {
        public bool CanAdd { get { return SelectedUser != null; } }
        public bool CanRemove { get { return (SelectedUser != null && SelectedUser.Id!="Super" && SelectedUser.Id!=User.Id); } }
        public List<User> Users { get; set; }
        public List<UserPossession> Possessions { get; set; }
        User selected;
        public User SelectedUser { get { return selected; } set { selected = value;Notify(); } }

        private void Notify()
        {
            NotifyOfPropertyChange(nameof(SelectedUser)); NotifyOfPropertyChange(nameof(Save)); NotifyOfPropertyChange(nameof(Remove));
        }

        public MyUsersViewModel()
        {
            Users = MainContext.GetEntities<User>().Where(u=>u.Id!="Any").ToList();
            Possessions = new List<UserPossession>();
            Possessions.Add(UserPossession.Expert);
            Possessions.Add(UserPossession.Junior);
            Possessions.Add(UserPossession.Middle);
            Possessions.Add(UserPossession.Super);
        }
        public Command Save { get { return new Command(CanAdd, new Action(SaveCmd)); } }
        public Command Remove { get { return new Command(CanRemove, new Action(RemoveCmd)); } }
        public Command Close { get { return new Command(true, new Action(CloseCmd)); } }

        private void CloseCmd()
        {
            TryClose();
        }

        private void SaveCmd()
        {
            try
            {
                if (SelectedUser.Id=="Super")
                {
                    SelectedUser.Possession = UserPossession.Super;
                }
                MainContext.SaveChanges();
                Message.ShowComMsg("Save Complated!");
            }
            catch (Exception ex)
            {
                string msg = Helper.GetMessage(ex);
                Message.ShowErrorMsg(msg);
            }
        }
        private void RemoveCmd()
        {
            try
            {
                MainContext.Remove(SelectedUser);
                Users.Remove(SelectedUser);
                MainContext.SaveChanges();
                NotifyOfPropertyChange(nameof(Users));
                Message.ShowComMsg("Removed!");
            }
            catch (Exception ex)
            {
                string msg = Helper.GetMessage(ex);
                Message.ShowErrorMsg(msg);
            }
        }
    }
}
