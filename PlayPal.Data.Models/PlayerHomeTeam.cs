using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayPal.Data.Models
{
    public class PlayerHomeTeam
    {
        /// <summary>
        /// The identifier of the player
        /// </summary>
        [Comment("The identifier of the player from the team")]
        [Required]
        [ForeignKey(nameof(Player))]
        public Guid PlayerId { get; set; }

        /// <summary>
        /// Player from the team
        /// </summary>
        public virtual Player Player { get; set; } = null!;

        /// <summary>
        /// The indentifier of the team of the player
        /// </summary>
        [Comment("The indentifier of the team of the player")]
        [Required]
        [ForeignKey(nameof(HomeTeam))]
        public Guid TeamId { get; set; }

        /// <summary>
        /// The team of the player
        /// </summary>
        public virtual HomeTeam HomeTeam { get; set; } = null!;
    }
}
