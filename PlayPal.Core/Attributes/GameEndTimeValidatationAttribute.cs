using PlayPal.Common.Notifications;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Core.Attributes
{
    public class GameEndTimeValidatationAttribute :ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public GameEndTimeValidatationAttribute(string startingTimePropertyName)
        {
            _comparisonProperty = startingTimePropertyName;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {

            if (value == null)
            {
                ErrorMessage = ErrorMessages.PropertyValueIsNull;

                return new ValidationResult(ErrorMessage);
            }

            var endTime = (DateTime)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
            {
                throw new ArgumentException("Property with this name not found");
            }
               

            DateTime? startingTime = (DateTime?)property.GetValue(validationContext.ObjectInstance);

            if (startingTime == null)
            {
                ErrorMessage = ErrorMessages.PropertyValueIsNull;

                return new ValidationResult(ErrorMessage);
            }

            if (endTime <= startingTime)
            {
                ErrorMessage = ErrorMessages.EndingTimeBeforeStartingTime;
                return new ValidationResult(ErrorMessage);
            }
                

            return ValidationResult.Success;
        }
    }
}
