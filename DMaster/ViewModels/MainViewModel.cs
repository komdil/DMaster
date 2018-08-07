using Caliburn.Micro;
using DMaster.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMaster.ViewModels
{
    public class MainViewModel:Conductor<object>
    {
        public ObservableCollection<User> Users { get; set; }

        public MainViewModel()
        {
            Users = new ObservableCollection<User>();
            var user = new User { Id = "KOMDILL" };
            MainContext mainContext = new MainContext();
            mainContext.Tasks.Add(new DTask {Title="Title",Assignee= user,Validator= user,CreatedBy= user,CreatedDate=DateTime.Today,FinishDate=DateTime.Today,Description="Desc" });
            mainContext.SaveChanges();
        }
    }
}
