using Microsoft.EntityFrameworkCore;
using PlayPal.Data.Models.Enums;
using PlayPal.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace PlayPal.Data.Models
{
    public class Ban : IDeletable
    {
        /// <summary>
        /// The identifier of the ban
        /// </summary>
        [Comment("The identifier of the ban")]
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The identifier of the administrator, who issued th ban
        /// </summary>
        [Comment("The identifier of the administrator, who issued th ban")]
        [Required]
        public Guid AdministratorId { get; set; }

        /// <summary>
        /// The administrator, who issued the ban
        /// </summary>
        public Administrator Administrator { get; set; } = null!;

        [Comment("The identifier of the player, who has been banned")]
        [Required]
        public Guid PlayerId { get; set; }

        /// <summary>
        /// The player, who has been banned
        /// </summary>
        public Player Player { get; set; } = null!;

        /// <summary>
        /// The reason for the ban
        /// </summary>
        [Comment("The reason for the ban")]
        [Required]
        public Reason Reason { get; set; }

        /// <summary>
        /// The date and hour, when the ban expires
        /// </summary>
        [Comment("The date and hour, when the ban expires")]
        [Required]
        public DateTime BannedTo { get; set; }

        /// <summary>
        /// Indicate if this player profile is considered deleted
        /// </summary>
        [Comment("Indicate if this ban is considered deleted")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
