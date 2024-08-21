﻿using System.ComponentModel.DataAnnotations;

namespace RoutingExample.CustomValidators
{
    public class MinimumValidatorAttribute: ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000;
        public string DefaultErrorMessage { get; set; }= "Year should not be less than {0}";
        public MinimumValidatorAttribute()
        {
            
        }

        public MinimumValidatorAttribute(int minimumYear)
        {
            MinimumYear = minimumYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year > MinimumYear)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear));
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}
