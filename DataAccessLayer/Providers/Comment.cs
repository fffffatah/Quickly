using System;
using System.Collections.Generic;

namespace DataAccessLayer.Providers
{
    /// <summary>
    /// Table of Comments in Task
    /// </summary>
    public partial class Comment
    {
        public Comment()
        {
            CommentAttachments = new HashSet<CommentAttachment>();
        }

        public Guid Id { get; set; }
        public string? TaskComment { get; set; }
        public Guid? TaskId { get; set; }
        public Guid? CommenterId { get; set; }

        public virtual User? Commenter { get; set; }
        public virtual Task? Task { get; set; }
        public virtual ICollection<CommentAttachment> CommentAttachments { get; set; }
    }
}
