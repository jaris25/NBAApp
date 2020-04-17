using Microsoft.EntityFrameworkCore;
using NbaApp.Data.Models.PlayersModels;
using NbaApp.Data.Models.Settings;

namespace NbaApp.Data.Services
{
    public class PlayersContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public IPlayersDatabaseSettings _playersDatabaseSettings { get; set; }

        public PlayersContext(IPlayersDatabaseSettings playersDatabaseSettings)
        {
            _playersDatabaseSettings = playersDatabaseSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_playersDatabaseSettings.ConnectionString);
            
        }

    }
}
