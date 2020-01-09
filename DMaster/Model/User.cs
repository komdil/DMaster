using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DMaster.Model
{
    public class User:EntityBase
    {
        [Key]
        public string Id { get; set; }
        public string Password { get; set; }
        public UserPossession Possession { get; set; }
        public virtual ObservableCollection<DTask> Tasks { get; set; }
        public virtual ObservableCollection<Comment> Comments { get; set; }
        public virtual ObservableCollection<DTask> ValidateTasks { get; set; }
        public virtual ObservableCollection<DTask> CreatedTasks { get; set; }
        public virtual ObservableCollection<Authorize> Authorizes { get; set; }
    }
    public enum UserPossession
    {
        Junior,
        Middle,
        Expert,
        Super
    }
}