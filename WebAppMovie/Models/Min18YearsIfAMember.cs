using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMovie.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 0 ||   // MembershipType.Unknown
                customer.MembershipTypeId == 1)     // MembershipType.PayAsYouGo
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Fecha de nacimiento es requerida.");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("El cliente debe tener al menos 18 años para tener una membresía.");
        }


    }
}