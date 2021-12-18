using EntityLayer.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.Task
{
    public class TaskWithAttachmentModel
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
        public virtual List<TaskAttachmentModel>? TaskAttachments { get; set; }
        public virtual List<CommentModel>? Comments { get; set; }
    }
}
