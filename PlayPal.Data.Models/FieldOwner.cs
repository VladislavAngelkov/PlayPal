using Microsoft.EntityFrameworkCore;
using PlayPal.Common.ValidationConstants;
using PlayPal.Data.Models.Enums;
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
        /// The name of the company that owns the field
        /// </summary>
        [Comment("The name of the company that owns the field")]
        [Required]
        [MaxLength(FieldOwnerConstants.CompanyNameMaxLength)]
        public string CompanyName { get; set; } = null!;

        /// <summary>
        /// The first name of the representive of the company that owns the field
        /// </summary>
        [Comment("The first name of the representive of the company that owns the field")]
        [Required]
        [MaxLength(FieldOwnerConstants.FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// The last name of the representive of the company that owns the field
        /// </summary>
        [Comment("The last name of the representive of the company that owns the field")]
        [Required]
        [MaxLength(FieldOwnerConstants.LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// The title of the representive
        /// </summary>
        [Comment("The title of the representive")]
        [Required]
        public Title Title { get; set; }

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
    }
}
