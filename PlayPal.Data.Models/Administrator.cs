using Microsoft.EntityFrameworkCore;
using PlayPal.Common.ValidationConstants;
using PlayPal.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayPal.Data.Models
{
    public class Administrator : IDeletable
    {
        public Administrator()
        {
            Id = Guid.NewGuid();
            Bans = new HashSet<Ban>();
        }

        /// <summary>
        /// The identifier of the Administrator profile
        /// </summary>
        [Comment("The identifier of the Administrator profile")]
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The first name of the Administrator
        /// </summary>
        [Comment("The first name of the Administrator")]
        [Required]
        [MaxLength(AdministratorConstants.FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// The last name of the Administrator
        /// </summary>
        [Comment("The last name of the Administrator")]
        [Required]
        [MaxLength(AdministratorConstants.LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// The identifier of the user, owning the administrator profile
        /// </summary>
        [Comment("The identifier of the user, owning the administrator profile")]
        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }

        /// <summary>
        /// The user oning the administrator profile
        /// </summary>
        public PlayPalUser? User { get; set; }

        /// <summary>
        /// Collection of all bans, issued by the administrator
        /// </summary>
        [Comment("Collection of all bans, issued by the administrator")]
        public virtual ICollection<Ban> Bans { get; set; }
    }
}
