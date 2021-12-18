using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.Comment
{
    public class CommentModel
    {
        public long Id { get; set; }
        public string? TaskComment { get; set; }
        public long TaskId { get; set; }
        public long CommenterId { get; set; }
        public List<CommentAttachmentModel>? CommentAttachments { get; set; }
    }
}
