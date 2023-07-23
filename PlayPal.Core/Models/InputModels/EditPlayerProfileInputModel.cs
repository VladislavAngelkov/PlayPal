using Microsoft.EntityFrameworkCore;
using PlayPal.Common.ValidationConstants;
using PlayPal.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PlayPal.Core.Models.ViewModels;

namespace PlayPal.Core.Models.InputModels
{
    public class EditPlayerProfileInputModel
    {
        public EditPlayerProfileInputModel()
        {
            Positions = new HashSet<PositionViewModel>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(PlayerConstants.NameMaxLength, MinimumLength = PlayerConstants.NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(PlayerConstants.CityMaxLength, MinimumLength = PlayerConstants.CityMinLength)]
        public string CurrentCity { get; set; } = null!;

        [Required]
        public Guid Position { get; set; }

        public ICollection<PositionViewModel> Positions { get; set; }

        [Required]
        [StringLength(PlayPalUserConstants.PasswordMaxLength, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;
    }
}
