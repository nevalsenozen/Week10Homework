using System;
using System.ComponentModel.DataAnnotations;

namespace EventManagerAPI.ValidationAttributes
{
    public class NoPastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime date && date < DateTime.Now)
            {
                return new ValidationResult("Event date cannot be in the past.");
            }
            return ValidationResult.Success;
            
        }
    }
}                       