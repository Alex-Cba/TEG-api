using Microsoft.EntityFrameworkCore;
using TEG_api.Common.Models;

namespace TEG_api.Data
{
    public class TEGContext : DbContext
    {
        public TEGContext(DbContextOptions<TEGContext> options) : base(options)
        {

        }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Dice> Dices { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchConfig> MatchConfigs { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<MissionsPlayer> MissionsPlayers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
