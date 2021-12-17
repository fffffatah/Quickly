using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    public class ImageMimeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IFormFile file;
            if (value != null)
            {
                file = (IFormFile)value;
                if (!(file.ContentType == "image/jpeg" || file.ContentType == "image/png"))
                {
                    return new ValidationResult(ErrorMessage = "* Invalid Image Type");
                }
            }
            return ValidationResult.Success;
        }
    }
}
