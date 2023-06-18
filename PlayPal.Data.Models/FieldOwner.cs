using Microsoft.EntityFrameworkCore;
using PlayPal.Common.ValidationConstants;
using PlayPal.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayPal.Data.Models
{
    public class FieldOwner : IDeletable
    {
        public FieldOwner()
        {
            Id = Guid.NewGuid();
            Fields = new HashSet<Field>();
        }

        /// <summary>
        /// Filed owner's identifier
        /// </summary>
        [Comment("Field owner's identifier.")]
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The identifier of the user, owning owner's profile
        /// </summary>
        [Comment("The identifier of the user, owning owner's profile")]
        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        /// <summary>
        /// The user enitity, owning owner's profile
        /// </summary>
        public virtual PlayPalUser User { get; set; } = null!;

        /// <summary>
        /// Field owner's physical address for official correspondence
        /// </summary>
        [Comment("Field owner's physical address for official correspondence")]
        [Required]
        [MaxLength(FieldOwnerConstants.ContactAddressMaxLength)]
        public string ContactAddress { get; set; } = null!;

        /// <summary>
        /// Fields owned by the field owner
        /// </summary>
        public virtual ICollection<Field> Fields { get; set; }

        /// <summary>
        /// Indicate if this player profile is considered deleted
        /// </summary>
        [Comment("Indicate if this field owner profile is considered deleted")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
