using System;
using System.ComponentModel.DataAnnotations;

namespace EventManagerAPI.ValidationAttributes
{
    public class MustStartWithUppercaseAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string str && str.Length > 0 && !char.IsUpper(str[0]))
            {
                return new ValidationResult("The first letter must be uppercase.");
            }
            return ValidationResult.Success;
        }
    }
}
