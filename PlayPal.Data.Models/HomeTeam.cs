using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayPal.Data.Models
{
    public class HomeTeam : Team
    {
        public HomeTeam()
            :base()
        {
            Players = new HashSet<PlayerHomeTeam>();
        }

        /// <summary>
        /// Collection of the players in the team
        /// </summary>
        public ICollection<PlayerHomeTeam> Players { get; set; }
    }
}
