using System;
using System.Collections.Generic;

namespace DataAccessLayer.Providers
{
    public partial class CommentAttachment
    {
        public Guid Id { get; set; }
        public string? FileUrl { get; set; }
        public Guid? CommentId { get; set; }

        public virtual Comment? Comment { get; set; }
    }
}
