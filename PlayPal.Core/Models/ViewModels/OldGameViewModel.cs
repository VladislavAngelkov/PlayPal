namespace PlayPal.Core.Models.ViewModels
{
    public class OldGameViewModel
    {
        public OldGameViewModel()
        {
            HomeTeamPlayerIds = new HashSet<Guid>();
            AwayTeamPlayerIds = new HashSet<Guid>();
        }
        public Guid Id { get; set; }

        public Guid CreatorId { get; set; }

        public string Field { get; set; } = null!;

        public ICollection<Guid> HomeTeamPlayerIds { get; set; }

        public ICollection<Guid> AwayTeamPlayerIds { get; set; }

        public DateTime StartingTime { get; set; }

        public DateTime EndingTime { get; set; }

        public int? HomeTeamGoals { get; set; }

        public int? AwayTeamGoals { get; set; }
    }
}
