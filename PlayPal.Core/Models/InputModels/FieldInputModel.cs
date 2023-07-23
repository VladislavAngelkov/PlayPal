using PlayPal.Common.ValidationConstants;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Core.Models.InputModels
{
    public class FieldInputModel
    {
        public FieldInputModel()
        {
            Id = Guid.NewGuid();    
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(FieldConstants.NameMaxLength, MinimumLength =FieldConstants.NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(FieldConstants.CityMaxLength, MinimumLength = FieldConstants.CityMinLength)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(FieldConstants.AddressMaxLength, MinimumLength = FieldConstants.AddressMinLength)]
        public string Address { get; set; } = null!;

        public Guid OwnerId { get; set; }
    }
}
