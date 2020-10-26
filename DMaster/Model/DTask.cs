using DMaster.Model.Helpers;
using OceanAirdrop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data;

namespace DMaster.Model
{
    public class DTask : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = "No Title";
        public string Descriptions { get; set; } = "Not Descriptions";
        public virtual User Assignee { get; set; }
        public string AssigneeId { get; set; }
        public virtual User Validator { get; set; }
        public string ValidatorId { get; set; }
        public virtual User CreatedBy { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Today;
        public DateTime FinishDate { get; set; } = DateTime.Today;
        public int PeriodId { get; set; }
        public virtual Period Period { get; set; }
        public virtual ObservableCollection<Comment> Comments { get; set; }
        public Status Status { get; set; } = Status.NotStarted;
        public Weight Weight { get; set; } = Weight.Low;

        public virtual string LowTitle
        {
            get
            {

                if (this.Title.Length > 40)
                {
                    return $"{Title.Substring(0, 40)}...";
                }
                else
                {
                    return Title;
                }
            }
        }
        public virtual string LowInfo
        {
            get
            {

                if (this.Descriptions.Length > 50)
                {
                    return $"{Descriptions.Substring(0, 50)}...";
                }
                else
                {
                    return Descriptions;
                }
            }
        }

        public string CopyTaskLink()
        {
            return Title + " -- " + Assignee?.Id;
        }

        public TimerType GetTimerType()
        {
            return DBHelper.GetTimerList().FirstOrDefault(a => a.pmo_num == this.Id.ToString());
        }
    }
}
