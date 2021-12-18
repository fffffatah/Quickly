using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.User
{
    public class UserResetPassModel
    {
        [Required(ErrorMessage = "* Password Required")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "* Password Must be at least 8 in Length and Must Contain Uppercase, Number and a Special Character")]
        public string? Pass { get; set; }
        [Required(ErrorMessage = "* Confirm Password Required")]
        [Compare("Pass")]
        public string? ConfirmedPass { get; set; }
    }
}
