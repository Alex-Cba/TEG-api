using Microsoft.EntityFrameworkCore;
using System;
using TEG_api.Common.Enums;
using TEG_api.Common.Models;

namespace TEG_api.Data
{
    public partial class TEGContext : DbContext
    {
        public TEGContext()
        {
        }
        public TEGContext(DbContextOptions<TEGContext> options) : base(options)
        {

        }
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<Continent> Continents { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Dice> Dices { get; set; }
        public virtual DbSet<Map> Maps { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<MatchConfig> MatchConfigs { get; set; }
        public virtual DbSet<Mission> Missions { get; set; }
        public virtual DbSet<PlayerGameSetup> PlayerGameSetups { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<DbHistory> DbHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.HasIndex(e => e.DiceId, "IX_Configurations_DiceId");

                entity.HasOne(d => d.Dice).WithMany(p => p.Configurations).HasForeignKey(d => d.DiceId);
            });

            modelBuilder.Entity<Continent>(entity =>
            {
                entity.HasIndex(e => e.MapId, "IX_Continents_MapId");

                entity.HasOne(d => d.Map).WithMany(p => p.Continents).HasForeignKey(d => d.MapId);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasIndex(e => e.ContinentId, "IX_Countries_ContinentId");

                entity.HasIndex(e => e.PlayerId, "IX_Countries_PlayerId");

                entity.HasOne(d => d.Continent).WithMany(p => p.Countries).HasForeignKey(d => d.ContinentId);
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasIndex(e => e.MapId, "IX_Matchs_MapId");

                entity.HasIndex(e => e.MatchConfigId, "IX_Matchs_MatchConfigId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Map).WithMany(p => p.Matches).HasForeignKey(d => d.MapId);

                entity.HasOne(d => d.MatchConfig).WithMany(p => p.Matches).HasForeignKey(d => d.MatchConfigId);
            });

            modelBuilder.Entity<MatchConfig>(entity =>
            {
                entity.HasIndex(e => e.ConfigurationId, "IX_MatchConfigs_ConfigurationId");

                entity.HasOne(d => d.Configuration).WithMany(p => p.MatchConfigs).HasForeignKey(d => d.ConfigurationId);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Players_UserId");

                entity.HasIndex(e => e.UserId, "Players_Users_UserId").IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.User).WithOne(p => p.Player).HasForeignKey<Player>(d => d.UserId);
            });

            modelBuilder.Entity<PlayerGameSetup>(entity =>
            {
                entity.ToTable("PlayerGameSetup");
                entity.HasIndex(e => e.TeamId, "IX_Players_TeamId");

                entity.HasIndex(e => e.MatchId, "IX_PlayerGameSetup_MatchId");

                entity.HasIndex(e => e.MissionId, "IX_PlayerGameSetup_MissionId");

                entity.HasIndex(e => e.PlayerId, "IX_PlayerGameSetup_PlayerId");
                entity.HasOne(d => d.Team).WithMany(p => p.PlayerGameSetups).HasForeignKey(d => d.TeamId);

                entity.HasOne(d => d.Match).WithMany(p => p.PlayerGameSetups).HasForeignKey(d => d.MatchId);

                entity.HasOne(d => d.Mission).WithMany(p => p.PlayerGameSetups).HasForeignKey(d => d.MissionId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder
                .Entity<User>()
                .Property(e => e.UserType)
                .HasConversion(
                        v => v.ToString(),
                        v => (UserType)Enum.Parse(typeof(UserType), v)
                );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
