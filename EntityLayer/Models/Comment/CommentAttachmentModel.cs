using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.Comment
{
    public class CommentAttachmentModel
    {
        public long Id { get; set; }
        public string? FileUrl { get; set; }
        public long? CommentId { get; set; }
    }
}
