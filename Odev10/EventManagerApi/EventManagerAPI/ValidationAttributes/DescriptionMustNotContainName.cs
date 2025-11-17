using System;
using System.ComponentModel.DataAnnotations;
using EventManagerAPI.Models;

namespace EventManagerAPI.ValidationAttributes
{
    public class DescriptionMustNotContainNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var eventInstance = (Event)validationContext.ObjectInstance;
            if (value is string description && !string.IsNullOrEmpty(eventInstance.Name))
            {
                if (description.Contains(eventInstance.Name))
                {
                    return new ValidationResult("Description must not contain the event name.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
