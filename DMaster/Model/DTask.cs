using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMaster.Model
{
    public class DTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual User Assignee { get; set; }
        public string AssigneeId { get; set; }
        public virtual User Validator { get; set; }
        public string ValidatorId { get; set; }
        public virtual User CreatedBy { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FinishDate { get; set; }

    }
}
