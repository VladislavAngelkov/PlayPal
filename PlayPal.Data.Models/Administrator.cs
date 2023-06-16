using Microsoft.EntityFrameworkCore;
using PlayPal.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayPal.Data.Models
{
    public class Administrator : IDeletable
    {
        public Administrator()
        {
            Bans = new HashSet<Ban>();
        }

        /// <summary>
        /// The identifier of the Administrator profile
        /// </summary>
        [Comment("The identifier of the Administrator profile")]
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The identifier of the user, owning the administrator profile
        /// </summary>
        [Comment("The identifier of the user, owning the administrator profile")]
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        /// <summary>
        /// The user oning the administrator profile
        /// </summary>
        public PlayPalUser User { get; set; } = null!;

        /// <summary>
        /// Collection of all bans, issued by the administrator
        /// </summary>
        [Comment("Collection of all bans, issued by the administrator")]
        public virtual ICollection<Ban> Bans { get; set; }

        /// <summary>
        /// Indicate if this administrator profile is considered deleted
        /// </summary>
        [Comment("Indicate if this administrator profile is considered deleted")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
