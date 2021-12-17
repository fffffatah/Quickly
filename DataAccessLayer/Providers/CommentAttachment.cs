using System;
using System.Collections.Generic;

namespace DataAccessLayer.Providers
{
    public partial class CommentAttachment
    {
        public long Id { get; set; }
        public string? FileUrl { get; set; }
        public long CommentId { get; set; }

        public virtual Comment Comment { get; set; } = null!;
    }
}
