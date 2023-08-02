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
            Id = Guid.NewGuid();
            PendingGames = new HashSet<PendingPlayerGame>();
            Teams = new HashSet<PlayerTeam>();
            Bans = new HashSet<Ban>();
            CreatedGames = new HashSet<Game>();
            Goals = new HashSet<Goal>();
            SubmittedReports = new HashSet<Report>();
            ReceivedReports = new HashSet<Report>();
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
        [MaxLength(PlayerConstants.CityMaxLength)]
        public string CurrentCity { get; set; } = null!;

        /// <summary>
        /// Normalized name of the player's city
        /// Used for finding nearby games.
        /// </summary>
        [Comment("Normalized name of the player's city")]
        [MaxLength(PlayerConstants.CityMaxLength)]
        public string? NormalizedCurrentCity { get; set; }

        /// <summary>
        /// The identifier of the preffered position of the player.
        /// </summary>
        [Comment("The identifier of the preffered position of the player.")]
        [Required]
        [ForeignKey(nameof(Position))]
        public Guid PositionId { get; set; }

        /// <summary>
        /// The preffered position of the player.
        /// </summary>
        public Position Position { get; set; } = null!;

        /// <summary>
        /// The identifier of the user, owning player's profile
        /// </summary>
        [Comment("The identifier of the user, owning player's profile")]
        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }

        /// <summary>
        /// The user enitity, owning player's profile
        /// </summary>
        public virtual PlayPalUser? User { get; set; }

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
        public virtual ICollection<PlayerTeam> Teams { get; set; }

        /// <summary>
        /// Collection of bans for the player profile
        /// </summary>
        public virtual ICollection<Ban> Bans { get; set; }

        /// <summary>
        /// List of all goals scored by the player
        /// </summary>
        public virtual ICollection<Goal> Goals { get; set; }

        [InverseProperty("ReportingPlayer")]
        public virtual ICollection<Report> SubmittedReports { get; set; }

        [InverseProperty("ReportedPlayer")]
        public virtual ICollection<Report> ReceivedReports { get; set; }

        /// <summary>
        /// The indentifier of the profile picture
        /// </summary>
        [Comment("The indentifier of the profile picture")]
        public string? ProfilePictureId { get; set; }
    }
}
