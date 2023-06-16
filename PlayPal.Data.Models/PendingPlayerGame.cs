using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayPal.Data.Models
{
    public class PendingPlayerGame
    {
        /// <summary>
        /// The identifier of the pending player
        /// </summary>
        [Comment("The identifier of the pending player")]
        [Required]
        [ForeignKey(nameof(Player))]
        public Guid PlayerId { get; set; }

        /// <summary>
        /// Pending player
        /// </summary>
        public virtual Player Player { get; set; } = null!;

        /// <summary>
        /// The identifier of the pending game
        /// </summary>
        [Comment("The identifier of the pending game")]
        [Required]
        [ForeignKey(nameof(Game))]
        public Guid GameId { get; set; }

        /// <summary>
        /// Pending game
        /// </summary>
        public virtual Game Game { get; set; } = null!;
    }
}
