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
        }

        /// <summary>
        /// The indentifier of the team
        /// </summary>
        [Comment("The indentifier of the team")]
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The identifier of the game, in which the team played
        /// </summary>
        [Comment("The identifier of the game, in which the team played")]
        [Required]
        [ForeignKey(nameof(Game))]
        public Guid GameID { get; set; }

        /// <summary>
        /// The game, in which the team played
        /// </summary>
        public virtual Game Game { get; set; } = null!;

        /// <summary>
        /// Indicate if this team is considered deleted
        /// </summary>
        [Comment("Indicate if this team is considered deleted")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
