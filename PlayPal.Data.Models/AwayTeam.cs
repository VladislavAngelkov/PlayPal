namespace PlayPal.Data.Models
{
    public class AwayTeam : Team
    {
        public AwayTeam()
            :base()
        {
            Players = new HashSet<PlayerAwayTeam>();
        }

        /// <summary>
        /// Collection of the players in the team
        /// </summary>
        public ICollection<PlayerAwayTeam> Players { get; set; }
    }
}
