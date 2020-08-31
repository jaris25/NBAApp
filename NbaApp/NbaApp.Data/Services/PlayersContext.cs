using Microsoft.EntityFrameworkCore;
using NbaApp.Data.Models.PlayersModels;
using NbaApp.Data.Models.Settings;
using NbaApp.Data.Models.StatisticsModels;

namespace NbaApp.Data.Services
{
    public class PlayersContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<CareerSummary> CareerSummaries { get; set; }
        public IPlayersDatabaseSettings _playersDatabaseSettings { get; set; }

        //public PlayersContext(IPlayersDatabaseSettings playersDatabaseSettings)
        //{
        //    _playersDatabaseSettings = playersDatabaseSettings;
        //}
        public PlayersContext(DbContextOptions<PlayersContext> options):
            base(options)
        {
            //_playersDatabaseSettings = playersDatabaseSettings;
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_playersDatabaseSettings.ConnectionString);
        //}

    }
}
