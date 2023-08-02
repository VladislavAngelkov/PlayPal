using PlayPal.Core.Attributes;

namespace PlayPal.Core.Models.InputModels
{
    public class BanInputModel
    {
        public BanInputModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public Guid AdministratorId { get; set; }

        public Guid PlayerId { get; set; }

        public string Reason { get; set; } = null!;

        [DateTime]
        public DateTime BannedTo { get; set; }

        public Guid ReportId { get; set; }
    }
}
