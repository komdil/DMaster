using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMaster.Model
{
    public class Comment:EntityBase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual User  User { get; set; }
        public string UserId { get; set; }
        public virtual DTask Task { get; set; }
        public int TaskId { get; set; }
        public string Text { get; set; }
    }
}
