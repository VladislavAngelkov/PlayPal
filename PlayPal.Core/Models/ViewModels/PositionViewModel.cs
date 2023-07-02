using PlayPal.Common.ValidationConstants;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Core.Models.ViewModels
{
    public class PositionViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Position")]
        [StringLength(PositionConstants.NameMaxLength, MinimumLength =PositionConstants.NameMinLength)]
        public string Name { get; set; } = null!;
    }
}
