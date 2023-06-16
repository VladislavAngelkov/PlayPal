using Microsoft.EntityFrameworkCore;
using PlayPal.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayPal.Data.Models
{
    public class Team : IDeletable
    {
        public Team()
        {
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
        public Guid? HomeGameID { get; set; }

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
        public Guid? AwayGameID { get; set; }

        /// <summary>
        /// The away game, in which the team played
        /// </summary>
        [InverseProperty("AwayTeam")]
        public virtual Game AwayGame { get; set; } = null!;

        /// <summary>
        /// Indicate if this team is considered deleted
        /// </summary>
        [Comment("Indicate if this team is considered deleted")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
