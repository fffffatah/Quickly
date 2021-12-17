using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string? TaskComment { get; set; }
        public Guid TaskId { get; set; }
        public Guid CommenterId { get; set; }
        public List<CommentAttachment>? CommentAttachments { get; set; }
    }
}
