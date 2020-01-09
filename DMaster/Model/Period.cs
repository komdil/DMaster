using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMaster.Model
{
    public class Period:EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime From { get; set; } = DateTime.Today;
        public DateTime To { get; set; } = DateTime.Today;
        public virtual ObservableCollection<DTask> Tasks { get; set; } = new ObservableCollection<DTask>();
        public string Goals { get; set; } = "No Goals";
        public string Title { get; set; } = "No Title";
        [Required]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public Status Status { get; set; }
    }
}
