using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectDetails { get; set; }
        public string? ProjectImageUrl { get; set; }
    }
}
