using Microsoft.EntityFrameworkCore;
using PlayPal.Common.ValidationConstants;
using PlayPal.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayPal.Data.Models
{
    public class Field : IDeletable
    {
        public Field()
        {
            Games = new HashSet<Game>();
        }

        /// <summary>
        /// Filed's identifier
        /// </summary>
        [Comment("Field's identifier.")]
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the field
        /// </summary>
        [Comment("The name of the field")]
        [Required]
        [MaxLength(FieldConstants.NameMaxLength)]
        public string Name { get; set; } = null!;

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
        public virtual FieldOwner Owner { get; set; } = null!;

        /// <summary>
        /// Collection of all games on that field
        /// </summary>
        public virtual ICollection<Game> Games { get; set; }
    }
}
