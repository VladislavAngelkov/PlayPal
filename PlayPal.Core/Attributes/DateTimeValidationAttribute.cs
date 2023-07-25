using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PlayPal.Common.Notifications;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Core.Attributes
{
    sealed public class DateTimeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {

            if (value == null)
            {
                ErrorMessage = ErrorMessages.PropertyValueIsNull;

                return new ValidationResult(ErrorMessage);
            }

            var time = (DateTime)value;


            if (time <= DateTime.UtcNow)
            {
                ErrorMessage = ErrorMessages.StartingTime;
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
