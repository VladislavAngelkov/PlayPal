﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlayPal.Data.EntityConfigurations;
using PlayPal.Data.Models;
using PlayPal.Data.Seeding;
using PlayPal.Data.Seeding.Interfaces;

namespace PlayPal.Data
{
    public class PlayPalDbContext : IdentityDbContext<PlayPalUser, PlayPalRole, Guid>
    {
        private readonly IEntityGenerator _generator;
        public PlayPalDbContext(
            DbContextOptions<PlayPalDbContext> options, IEntityGenerator generator)
            : base(options)
        {
            _generator = generator;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureEntities(_generator);

            base.OnModelCreating(builder);
        }
    }
    
}