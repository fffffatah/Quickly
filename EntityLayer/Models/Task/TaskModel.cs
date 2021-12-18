using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.Task
{
    public class TaskModel
    {
        public long Id { get; set; }
        public string? TaskTitle { get; set; }
        public string? TaskDescription { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? Deadline { get; set; }
        public string? TaskStatus { get; set; }
        public string? TaskType { get; set; }
        public long? ProjectId { get; set; }
        public long? AssignedTo { get; set; }
    }
}
