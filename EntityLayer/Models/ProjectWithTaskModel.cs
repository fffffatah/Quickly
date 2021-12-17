using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class ProjectWithTaskModel
    {
        public long Id { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectDetails { get; set; }
        public string? ProjectImageUrl { get; set; }
        public List<TaskWithAttachmentModel>? Tasks { get; set; }
    }
}
