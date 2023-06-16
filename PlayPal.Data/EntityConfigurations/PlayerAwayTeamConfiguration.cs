using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Models;

namespace PlayPal.Data.EntityConfigurations
{
    public class PlayerAwayTeamConfiguration : IEntityTypeConfiguration<PlayerAwayTeam>
    {
        public void Configure(EntityTypeBuilder<PlayerAwayTeam> builder)
        {
            builder.HasKey(pht => new
            {
                pht.PlayerId,
                pht.TeamId
            });

            builder.HasOne(pht => pht.Player)
                .WithMany(p => p.AwayTeams)
                .HasForeignKey(pht => pht.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pht => pht.AwayTeam)
                .WithMany(ht => ht.Players)
                .HasForeignKey(pht => pht.TeamId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
