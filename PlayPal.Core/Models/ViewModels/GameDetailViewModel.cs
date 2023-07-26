namespace PlayPal.Core.Models.ViewModels
{
    public class GameDetailViewModel
    {
        public GameDetailViewModel()
        {
            PendingPlayers = new HashSet<GameDetailPlayerViewModel>();
            HomeTeam = new HashSet<GameDetailPlayerViewModel>();
            AwayTeam = new HashSet<GameDetailPlayerViewModel>();
        }

        public Guid Id { get; set; }

        public string Field { get; set; } = null!;

        public string Creator { get; set; } = null!;

        public Guid CreatorId { get; set; }

        public DateTime StartingTime { get; set; }

        public DateTime EndingTime { get; set;}

        public ICollection<GameDetailPlayerViewModel> PendingPlayers { get; set; }


        public Guid HomeTeamId { get; set; }

        public ICollection<GameDetailPlayerViewModel> HomeTeam { get; set; }

        public Guid awaitTeamId { get; set; }

        public ICollection<GameDetailPlayerViewModel> AwayTeam { get; set; }
    }
}
