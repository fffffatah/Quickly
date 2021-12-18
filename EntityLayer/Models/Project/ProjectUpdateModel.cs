using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes;

namespace EntityLayer.Models.Project
{
    public class ProjectUpdateModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "* Project Name Required")]
        public string? ProjectName { get; set; }
        [Required(ErrorMessage = "* Project Details Required")]
        public string? ProjectDetails { get; set; }
        public string? ProjectImageUrl { get; set; }
        [ImageMimeValidation]
        public IFormFile? ProjectImage { get; set; }
    }
}
