using PlayPal.Common.ValidationConstants;
using PlayPal.Core.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Core.Models.InputModels
{
    public class CreatePlayerInputModel 
    {
        public CreatePlayerInputModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(PlayerConstants.NameMaxLength, MinimumLength = PlayerConstants.NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(PlayerConstants.CityMaxLength, MinimumLength = PlayerConstants.CityMinLength)]
        public string City { get; set; } = null!;

        public Guid Position { get; set; } 

        public ICollection<PositionViewModel>? Positions { get; set; }
    }
}
