using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Models;

namespace PlayPal.Data.EntityConfigurations
{
    public class PlayerTeamConfiguration : IEntityTypeConfiguration<PlayerTeam>
    {
        public void Configure(EntityTypeBuilder<PlayerTeam> builder)
        {
            builder.HasKey(pht => new
            {
                pht.PlayerId,
                pht.TeamId
            });

            builder.HasOne(pht => pht.Player)
                .WithMany(p => p.Teams)
                .HasForeignKey(pht => pht.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pht => pht.Team)
                .WithMany(ht => ht.Players)
                .HasForeignKey(pht => pht.TeamId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
