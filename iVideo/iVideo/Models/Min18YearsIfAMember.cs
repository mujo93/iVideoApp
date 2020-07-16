using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iVideo.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (!customer.Birthdate.HasValue)
                return new ValidationResult("Birthdate is required.");
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18) ? 
                ValidationResult.Success : 
                new ValidationResult(ErrorMessage = "Customer has to be older than 18 years old to go on a membership.");
        }
    }
}