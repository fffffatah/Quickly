using System;
using System.Collections.Generic;

namespace DataAccessLayer.Providers
{
    public partial class TaskAttachment
    {
        public Guid Id { get; set; }
        public string? FileUrl { get; set; }
        public Guid? TaskId { get; set; }

        public virtual Task? Task { get; set; }
    }
}
