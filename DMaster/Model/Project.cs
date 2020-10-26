using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMaster.Model
{
    public class Project : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual ObservableCollection<Period> Periods { get; set; } = new ObservableCollection<Period>();
        [Index(IsUnique = true)]
        [MaxLength(255)]
        public string Name { get; set; } = "No Name";
        public DateTime Start { get; set; } = DateTime.Today;
        public DateTime Finish { get; set; } = DateTime.Today;
        public Status Status { get; set; } = Status.NotStarted;
        public string Descriptions { get; set; } = "No Descriptions";
        public override string ToString()
        {
            return Name;
        }
    }
    public enum Status
    {
        NotStarted,
        InProgress,
        Done
    }
    public enum Weight
    {
        Low,
        Big,
        High
    }
}
