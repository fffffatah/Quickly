using System;
using System.Collections.Generic;

namespace DataAccessLayer.Providers
{
    public partial class Task
    {
        public Task()
        {
            Comments = new HashSet<Comment>();
            TaskAttachments = new HashSet<TaskAttachment>();
        }

        public long Id { get; set; }
        public string? TaskTitle { get; set; }
        public string? TaskDescription { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? Deadline { get; set; }
        public string? TaskStatus { get; set; }
        public string? TaskType { get; set; }
        public long ProjectId { get; set; }
        public long AssignedTo { get; set; }

        public virtual User AssignedToNavigation { get; set; } = null!;
        public virtual Project Project { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<TaskAttachment> TaskAttachments { get; set; }
    }
}
