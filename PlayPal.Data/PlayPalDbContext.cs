using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlayPal.Data.EntityConfigurations;
using PlayPal.Data.Models;

namespace PlayPal.Data
{
    public class PlayPalDbContext : IdentityDbContext<PlayPalUser>
    {
        public PlayPalDbContext(DbContextOptions<PlayPalDbContext> options) : base(options)
        {
            
        }

        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<Administrator> Administrators { get; set; } = null!;   
        public DbSet<AwayTeam> AwayTeams { get; set; } = null!;
        public DbSet<HomeTeam> HomeTeams { get; set; } = null!;
        public DbSet<Ban> Bans { get; set; } = null!;
        public DbSet<Field> Fields { get; set; } = null!;
        public DbSet<FieldOwner> FieldOwners { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Goal> Goals { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<PendingPlayerGame> PendingPlayersGames { get; set; } = null!;
        public DbSet<PlayerHomeTeam> PlayersHomeTeams { get; set; } = null!;
        public DbSet<PlayerAwayTeam> PlayersAwayTeams { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<PendingPlayerGame>(new PendingPlayerGameConfiguration());

            builder.ApplyConfiguration<Message>(new MessageConfiguration());

            builder.ApplyConfiguration<Ban>(new BanConfiguration());

            builder.ApplyConfiguration<Game>(new GameConfiguration());

            builder.ApplyConfiguration<Goal>(new GoalConfiguration());

            builder.ApplyConfiguration<PlayerHomeTeam>(new PlayerHomeTeamConfiguration());

            builder.ApplyConfiguration<PlayerAwayTeam>(new PlayerAwayTeamConfiguration());

            base.OnModelCreating(builder);
        }
    }
    
}