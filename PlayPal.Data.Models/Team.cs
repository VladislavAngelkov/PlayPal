using Microsoft.EntityFrameworkCore;
using PlayPal.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace PlayPal.Data.Models
{
    public class Team : IDeletable
    {
        public Team()
        {
            Id = Guid.NewGuid();
            Players = new HashSet<PlayerTeam>();
        }

        /// <summary>
        /// The indentifier of the team
        /// </summary>
        [Comment("The indentifier of the team")]
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Collection of the players in the team
        /// </summary>
        public ICollection<PlayerTeam> Players { get; set; }

        /// <summary>
        /// The identifier of the home game, in which the team played
        /// </summary>
        [Comment("The identifier of the home game, in which the team played")]
        [ForeignKey(nameof(HomeGame))]
        [AllowNull]
        public Guid? HomeGameId { get; set; }

        /// <summary>
        /// The home game, in which the team played
        /// </summary>
        [InverseProperty("HomeTeam")]
        public virtual Game HomeGame { get; set; } = null!;

        /// <summary>
        /// The identifier of the away game, in which the team played
        /// </summary>
        [Comment("The identifier of the away game, in which the team played")]
        [ForeignKey(nameof(AwayGame))]
        public Guid? AwayGameId { get; set; }

        /// <summary>
        /// The away game, in which the team played
        /// </summary>
        [InverseProperty("AwayTeam")]
        public virtual Game AwayGame { get; set; } = null!;
    }
}
