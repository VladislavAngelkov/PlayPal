using Microsoft.EntityFrameworkCore;
using PlayPal.Common.ValidationConstants;
using PlayPal.Data.Models.Enums;
using PlayPal.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayPal.Data.Models
{
    public class Player : IDeletable
    {
        public Player()
        {
            PendingGames = new HashSet<PendingPlayerGame>();
            HomeTeams = new HashSet<PlayerHomeTeam>();
            AwayTeams = new HashSet<PlayerAwayTeam>();
            Bans = new HashSet<Ban>();
            CreatedGames = new HashSet<Game>();
            Goals = new HashSet<Goal>();
        }

        /// <summary>
        /// Player's identifier
        /// </summary>
        [Comment("Player's identifier.")]
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The name, that player will be seen with by other users
        /// </summary>
        [Comment("The name, that player will be seen with by other users.")]
        [Required]
        [MaxLength(PlayerConstants.NameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// The current location of the player 
        /// Used for finding nearby games.
        /// </summary>
        [Comment("The current location of the player. Its used for finding nearby games.")]
        [Required]
        [MaxLength(PlayerConstants.CitiMaxLength)]
        public string CurrentCity { get; set; } = null!;

        /// <summary>
        /// The preffered position of the player.
        /// </summary>
        [Comment("The preffered position of the player.")]
        [Required]
        public Position Position { get; set; }

        /// <summary>
        /// The identifier of the user, owning player's profile
        /// </summary>
        [Comment("The identifier of the user, owning player's profile")]
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        /// <summary>
        /// The user enitity, owning player's profile
        /// </summary>
        public virtual PlayPalUser User { get; set; } = null!;

        /// <summary>
        /// Collection of games, that the player has applied to, but is still not accepted in any of the two teams
        /// </summary>
        public virtual ICollection<PendingPlayerGame> PendingGames { get; set; }

        /// <summary>
        /// Collection of the games, created by the player
        /// </summary>
        public virtual ICollection<Game> CreatedGames { get; set; }

        /// <summary>
        /// Collection of all HomeTeams that the player was part of
        /// For every game the HomeTeam is different
        /// </summary>
        public virtual ICollection<PlayerHomeTeam> HomeTeams { get; set; }

        /// <summary>
        /// Collection of all AwayTeams that the player was part of
        /// For every game the AwayTeam is different
        /// </summary>
        public virtual ICollection<PlayerAwayTeam> AwayTeams { get; set; }

        /// <summary>
        /// Collection of bans for the player profile
        /// </summary>
        public virtual ICollection<Ban> Bans { get; set; }

        /// <summary>
        /// List of all goals scored by the player
        /// </summary>
        public virtual ICollection<Goal> Goals { get; set; }

        /// <summary>
        /// Indicate if this player profile is considered deleted
        /// </summary>
        [Comment("Indicate if this player profile is considered deleted")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
