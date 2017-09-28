using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace moviewatch.Models
{
    public class Men18yrs: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MemberShipId == 1)
            {
                return ValidationResult.Success;
            }
            else
            {
                if (customer.DOB == null)
                    return new ValidationResult("Bithdate is Required!");
                else
                {
                    var age = DateTime.Today.Year - customer.DOB.Value.Year;
                    if (age >= 18)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("User must be atleast 18 years of age!");
                    }

                }
            }
        }
    }
}