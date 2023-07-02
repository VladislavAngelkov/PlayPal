using Microsoft.EntityFrameworkCore;
using PlayPal.Common.ValidationConstants;
using PlayPal.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Data.Models
{
    public class Position : IDeletable
    {
        /// <summary>
        /// The identifier of the position
        /// </summary>
        [Comment("The identifier of the position")]
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the postion
        /// </summary>
        [Comment("The name of the postion")]
        [Required]
        [MaxLength(PositionConstants.NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
