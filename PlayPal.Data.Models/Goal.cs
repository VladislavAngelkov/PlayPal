using Microsoft.EntityFrameworkCore;
using PlayPal.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayPal.Data.Models
{
    public class Goal : IDeletable
    {
        /// <summary>
        /// The goal identifier
        /// </summary>
        [Comment("The goal identifier")]
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The indentifier of the player, who scored the goal
        /// </summary>
        [Comment("The indentifier of the player, who scored the goal")]
        [Required]
        [ForeignKey(nameof(Player))]
        public Guid PlayerId { get; set; }

        /// <summary>
        /// The player, who scored the goal
        /// </summary>
        public virtual Player Player { get; set; } = null!;

        [Comment("The identifier of the game in which the goal was scored")]
        [Required]
        [ForeignKey(nameof(Game))]
        public Guid GameId { get; set; }

        /// <summary>
        /// The game in which the goal was scored
        /// </summary>
        public virtual Game Game { get; set; } = null!;

        /// <summary>
        /// Indicates if the goals is autogoal
        /// </summary>
        [Comment("Indicates if the goals is autogoal")]
        [Required]
        public bool IsAutoGoal { get; set; }
    }
}
