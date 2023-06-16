using Microsoft.EntityFrameworkCore;
using PlayPal.Common.ValidationConstants;
using PlayPal.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayPal.Data.Models
{
    public class Field : IDeletable
    {
        /// <summary>
        /// Filed's identifier
        /// </summary>
        [Comment("Field's identifier.")]
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the city where the field is located
        /// </summary>
        [Comment("The name of the city where the field is located")]
        [Required]
        [MaxLength(FieldConstants.CityMaxLength)]
        public string City { get; set; } = null!;

        /// <summary>
        /// The address of the field (district, street, number)
        /// </summary>
        [Comment("The address of the field (district, street, number)")]
        [Required]
        [MaxLength(FieldConstants.AddressMaxLength)]
        public string Address { get; set; } = null!;

        /// <summary>
        /// The identifier of the field owner
        /// </summary>
        [Comment("The identifier of the field owner")]
        [Required]
        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }

        /// <summary>
        /// The field owner
        /// </summary>
        public FieldOwner Owner { get; set; } = null!;

        /// <summary>
        /// Indicate if this field record is considered deleted
        /// </summary>
        [Comment("Indicate if this field record is considered deleted")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
