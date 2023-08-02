using Microsoft.AspNetCore.Http;
using PlayPal.Common.Notifications;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Core.Attributes
{
    public class PictureValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {

            if (value == null)
            {
                ErrorMessage = ErrorMessages.PropertyValueIsNull;

                return new ValidationResult(ErrorMessage);
            }

            var file = (IFormFile)value;

            var contentType = file.ContentType.ToLowerInvariant();

            if (contentType != "image/gif" &&
                contentType != "image/jpeg" &&
                contentType != "image/png")
            {
                ErrorMessage = ErrorMessages.FileWorngFormat;

                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
