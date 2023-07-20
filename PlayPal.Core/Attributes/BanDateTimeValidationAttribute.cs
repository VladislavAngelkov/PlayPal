using System.ComponentModel.DataAnnotations;

namespace PlayPal.Core.Attributes
{
    sealed public class BanDateTimeAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var bannedTo = ((DateTime)value).ToUniversalTime();

            if (bannedTo<=DateTime.UtcNow)
            {
                return false;
            }

            return true;
        }
    }
}
