using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Providers;

namespace ValidationAttributes
{
    public class EmailValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (DataAccessFactory.UserDataAccess().IsEmailTaken(value.ToString()))
                {
                    return new ValidationResult(ErrorMessage = "* Email Taken");
                }
            }
            return ValidationResult.Success;
        }
    }
}