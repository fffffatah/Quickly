using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.User
{
    public class UserLoginModel
    { 
        [Required(ErrorMessage = "* Email Required")]
        [EmailAddress(ErrorMessage = "* Invalid Email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "* Password Required")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "* Password Must be at least 8 in Length and Must Contain Uppercase, Number and a Special Character")]
        public string? Pass { get; set; }
        public bool RememberMe { get; set; }
    }
}
