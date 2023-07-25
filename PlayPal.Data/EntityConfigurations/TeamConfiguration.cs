using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Models;

namespace PlayPal.Data.EntityConfigurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasOne(t => t.HomeGame)
                .WithOne(hg => hg.HomeTeam)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(t => t.HomeGameId)
                .IsRequired(false);
            builder.Property(t => t.AwayGameId)
                .IsRequired(false);

            builder.HasOne(t => t.AwayGame)
                .WithOne(ag => ag.AwayTeam)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
