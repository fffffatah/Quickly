using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class TaskWithAttachment
    {
        public Guid Id { get; set; }
        public string? TaskTitle { get; set; }
        public string? TaskDescription { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? Deadline { get; set; }
        public string? TaskStatus { get; set; }
        public string? TaskType { get; set; }
        public virtual List<TaskAttachment>? TaskAttachments { get; set; }
        public virtual List<Comment>? Comments { get; set; }
    }
}
