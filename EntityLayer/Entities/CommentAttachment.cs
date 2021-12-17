using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class CommentAttachment
    {
        public Guid Id { get; set; }
        public string? FileUrl { get; set; }
        public Guid? CommentId { get; set; }
    }
}
