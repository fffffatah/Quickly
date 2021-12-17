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

        public Guid Id { get; set; }
        public string? TaskTitle { get; set; }
        public string? TaskDescription { get; set; }
        public DateOnly? CreatedAt { get; set; }
        public DateOnly? Deadline { get; set; }
        public string? TaskStatus { get; set; }
        public string? TaskType { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<TaskAttachment> TaskAttachments { get; set; }
    }
}
