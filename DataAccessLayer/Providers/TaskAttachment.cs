using System;
using System.Collections.Generic;

namespace DataAccessLayer.Providers
{
    public partial class TaskAttachment
    {
        public long Id { get; set; }
        public string? FileUrl { get; set; }
        public long TaskId { get; set; }

        public virtual Task Task { get; set; } = null!;
    }
}
