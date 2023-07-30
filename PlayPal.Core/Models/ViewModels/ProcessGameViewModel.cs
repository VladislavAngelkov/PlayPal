namespace PlayPal.Core.Models.ViewModels
{
    public class ProcessGameViewModel
    {
        public ProcessGameViewModel()
        {
            HomePlayers = new HashSet<PlayerViewModel>();
            AwayPlayers = new HashSet<PlayerViewModel>();
        }
        public Guid Id { get; set; }

        public Guid CreatorId { get; set; }

        public string Field { get; set; }

        public ICollection<PlayerViewModel> HomePlayers { get; set; }

        public ICollection<PlayerViewModel> AwayPlayers { get; set; }

        public DateTime StartingTime { get; set; }

        public DateTime EndingTime { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public bool IsProcessed { get; set; }
    }
}
