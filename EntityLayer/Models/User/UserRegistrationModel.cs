using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ValidationAttributes;

namespace EntityLayer.Models.User
{
    public class UserRegistrationModel
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string? ProfileImageUrl { get; set; }
        [ImageMimeValidation]
        public IFormFile? ProfileImage { get; set; }
        [Required(ErrorMessage = "* Full Name Required")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "* Email Required")]
        [EmailValidation]
        [EmailAddress(ErrorMessage = "* Invalid Email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "* Phone Required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "* Phone Number Must be 11 Digits")]
        [PhoneValidation]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "* Password Required")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "* Password Must be at least 8 in Length and Must Contain Uppercase, Number and a Special Character")]
        public string? Pass { get; set; }
        [Required(ErrorMessage = "* Confirm Password Required")]
        [Compare("Pass")]
        public string? ConfirmedPass { get; set; }
        public string? UserType { get; set; }
        public bool IsVerified { get; set; }
    }
}
