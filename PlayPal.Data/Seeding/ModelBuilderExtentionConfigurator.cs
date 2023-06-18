using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlayPal.Data.EntityConfigurations;
using PlayPal.Data.Models;
using PlayPal.Data.Seeding.Interfaces;

namespace PlayPal.Data.Seeding
{
    internal static class ModelBuilderExtentionConfigurator 
    {
        internal static void ConfigureEntities(this ModelBuilder builder, IEntityGenerator generator)
        {
            builder.ApplyConfiguration<PlayPalUser>(new PlayPalUserConfiguration(generator));

            builder.ApplyConfiguration<PlayPalRole>(new PlayPalRoleConfiguration(generator));

            builder.ApplyConfiguration<IdentityUserRole<Guid>>(new UserRoleConfiguration(generator));

            builder.ApplyConfiguration<PendingPlayerGame>(new PendingPlayerGameConfiguration());

            builder.ApplyConfiguration<Message>(new MessageConfiguration());

            builder.ApplyConfiguration<Ban>(new BanConfiguration());

            builder.ApplyConfiguration<Game>(new GameConfiguration());

            builder.ApplyConfiguration<Goal>(new GoalConfiguration());

            builder.ApplyConfiguration<PlayerTeam>(new PlayerTeamConfiguration());

            builder.ApplyConfiguration<Team>(new TeamConfiguration());
        }
    }
}
