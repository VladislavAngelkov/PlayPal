using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlayPal.Data.Models;
using System.Reflection;

namespace PlayPal.Data
{
    public class PlayPalDbContext : IdentityDbContext<PlayPalUser, IdentityRole<Guid>, Guid>
    {
        public PlayPalDbContext(
            DbContextOptions<PlayPalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<Administrator> Administrators { get; set; } = null!;   
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<Ban> Bans { get; set; } = null!;
        public DbSet<Field> Fields { get; set; } = null!;
        public DbSet<FieldOwner> FieldOwners { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Goal> Goals { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<PendingPlayerGame> PendingPlayersGames { get; set; } = null!;
        public DbSet<PlayerTeam> PlayersTeams { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!; 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var currentAssembly = Assembly.GetAssembly(typeof(PlayPalDbContext));
            builder.ApplyConfigurationsFromAssembly(currentAssembly!);

            base.OnModelCreating(builder);
        }
    }
    
}