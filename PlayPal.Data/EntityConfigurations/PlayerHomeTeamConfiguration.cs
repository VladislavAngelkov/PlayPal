using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Models;

namespace PlayPal.Data.EntityConfigurations
{
    public class PlayerHomeTeamConfiguration : IEntityTypeConfiguration<PlayerHomeTeam>
    {
        public void Configure(EntityTypeBuilder<PlayerHomeTeam> builder)
        {
            builder.HasKey(pht => new
            {
                pht.PlayerId,
                pht.TeamId
            });

            builder.HasOne(pht => pht.Player)
                .WithMany(p => p.HomeTeams)
                .HasForeignKey(pht => pht.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pht => pht.HomeTeam)
                .WithMany(ht => ht.Players)
                .HasForeignKey(pht => pht.TeamId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
