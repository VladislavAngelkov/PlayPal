using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Models;

namespace PlayPal.Data.EntityConfigurations
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        void IEntityTypeConfiguration<Report>.Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasOne(r => r.ReportingPlayer)
                .WithMany(p => p.SubmittedReports)
                .HasForeignKey(r => r.ReportingPlayerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.ReportedPlayer)
                .WithMany(p => p.ReceivedReports)
                .HasForeignKey(r => r.ReportedPlayerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
