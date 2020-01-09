using DMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMaster.ViewModels
{
    public class TaskInfoViewModel:BaseViewModel
    {
        public DTask SelectedTask { get; set; }
        public TaskInfoViewModel(DTask dTask)
        {
            SelectedTask = dTask;
            ActiveItem = new CommentViewModel(SelectedTask);
        }
    }
}
