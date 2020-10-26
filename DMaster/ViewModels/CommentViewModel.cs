using DMaster.Model;
using DMaster.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DMaster.ViewModels
{
    public class CommentViewModel:BaseViewModel
    {
        DTask task;
        public DTask Task { get { return task; } set { task = value;Notify(); }}
        string text;
        public string TextComment { get { return text; } set { text = value;Notify(); } }
        public Brush MyColor { get; set; }
        private void Notify()
        {
            NotifyOfPropertyChange(nameof(Task));
            NotifyOfPropertyChange(nameof(AddComment));
            NotifyOfPropertyChange(nameof(TextComment));
        }
        public CommentViewModel(DTask dTask)
        {
            LoadTask(dTask);
        }
        void LoadTask(DTask dTask)
        {
            Task = MainContext.GetEntities<DTask>().Single(a => a.Id == dTask.Id);
        }
        public Command AddComment { get { return new Command(true, new Action(AddCommentCmd)); } }

        private void AddCommentCmd()
        {
            if (Task!=null && TextComment!="")
            {
                Comment comment = new Comment();
                comment.Date = DateTime.Now;
                comment.Task = Task;
                comment.User = MainContext.GetEntities<User>().Single(a => a.Id == User.Id);
                comment.Text = TextComment;
                MainContext.AddEntity(comment);
                MainContext.SaveChanges();
                TextComment = "";
            }
           
        }
    }
}
