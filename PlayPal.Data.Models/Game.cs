using Microsoft.EntityFrameworkCore;
using PlayPal.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayPal.Data.Models
{
    public class Game : IDeletable
    {
        public Game()
        {
            Goals = new HashSet<Goal>();
            PendingPlayers = new HashSet<PendingPlayerGame>();
        }

        /// <summary>
        /// Game identifier
        /// </summary>
        [Comment("Game identifier")]
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The identifier of the player who has created the game
        /// </summary>
        [Comment("The identifier of the player who has created the game")]
        [Required]
        [ForeignKey(nameof(Creator))]
        public Guid CreatorId { get; set; }

        /// <summary>
        /// The player who has created the game
        /// </summary>
        public virtual Player Creator { get; set; } = null!;

        /// <summary>
        /// The home team
        /// </summary>
        [InverseProperty("HomeGame")]
        public virtual Team HomeTeam { get; set; } = null!;

        /// <summary>
        /// The away team
        /// </summary>
        [InverseProperty("AwayGame")]
        public virtual Team AwayTeam { get; set; } = null!;

        /// <summary>
        /// The identifier of the field, where the game is played
        /// </summary>
        [Comment("The identifier of the field, where the game is played")]
        [Required]
        [ForeignKey(nameof(Field))]
        public Guid FieldId { get; set; }

        /// <summary>
        /// The field, where the game is played
        /// </summary>
        public virtual Field Field { get; set; } = null!;

        /// <summary>
        /// Mark the starting time of the game
        /// </summary>
        [Comment("Mark the starting time of the game")]
        [Required]
        public DateTime StartingTime { get; set; }

        /// <summary>
        /// Mark the ending time of the game
        /// </summary>
        [Comment("Mark the ending time of the game")]
        [Required]
        public DateTime EndingTime { get; set; }

        /// <summary>
        /// Collection of the goals, scored in the game
        /// </summary>
        [Comment("Collection of the goals, scored in the game")]
        public virtual ICollection<Goal> Goals { get; set; }

        /// <summary>
        /// List of players that are awaiting for team assignment
        /// </summary>
        [Comment("List of players that are awaiting for team assignment")]
        public virtual ICollection<PendingPlayerGame> PendingPlayers { get; set; }

        /// <summary>
        /// Indicate if this game is considered deleted
        /// </summary>
        [Comment("Indicate if this game is considered deleted")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
