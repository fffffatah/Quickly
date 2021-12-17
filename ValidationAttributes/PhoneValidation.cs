using DataAccessLayer.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    public class PhoneValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (DataAccessFactory.UserDataAccess().IsPhoneTaken(value.ToString()))
                {
                    return new ValidationResult(ErrorMessage = "* Phone Taken");
                }
            }
            return ValidationResult.Success;
        }
    }
}
