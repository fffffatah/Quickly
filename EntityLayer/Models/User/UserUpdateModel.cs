using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes;

namespace EntityLayer.Models.User
{
    public class UserUpdateModel
    {
        public string? ProfileImageUrl { get; set; }
        [ImageMimeValidation]
        [ImageFilter]
        public IFormFile? ProfileImage { get; set; }
        public string? FullName { get; set; }
    }
}
