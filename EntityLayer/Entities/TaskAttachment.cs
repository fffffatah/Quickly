using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class TaskAttachment
    {
        public Guid Id { get; set; }
        public string? FileUrl { get; set; }
        public Guid TaskId { get; set; }
    }
}
