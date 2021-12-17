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

        public long Id { get; set; }
        public string? TaskComment { get; set; }
        public long TaskId { get; set; }
        public long CommenterId { get; set; }

        public virtual User Commenter { get; set; } = null!;
        public virtual Task Task { get; set; } = null!;
        public virtual ICollection<CommentAttachment> CommentAttachments { get; set; }
    }
}
