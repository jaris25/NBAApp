using Microsoft.EntityFrameworkCore;
using NbaApp.Models.PlayersModels;

namespace NbaApp.Models
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
