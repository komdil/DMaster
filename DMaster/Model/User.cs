using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMaster.Model
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public virtual ObservableCollection<DTask> Tasks { get; set; }
        public virtual ObservableCollection<DTask> ValidateTasks { get; set; }
        public virtual ObservableCollection<DTask> CreatedTasks { get; set; }
    }
}