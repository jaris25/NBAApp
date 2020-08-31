using Microsoft.EntityFrameworkCore;
using NbaApp.Data.Models.PlayersModels;
using NbaApp.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NbaApp.Tests
{
    public class PlayersDataServiceShould
    {
        [Fact]
        public async Task GetAllPlayers()
        {
            var options = new DbContextOptionsBuilder<PlayersContext>()
                .UseInMemoryDatabase(databaseName: "MovieListDatabase")
                .Options;

            using (var context = new PlayersContext(options))
            {

                context.Players.Add(new Player { Id = 1 });
                context.Players.Add(new Player { Id = 2 });
                context.SaveChanges();
            }

            using (var context = new PlayersContext(options))
            {
                PlayersDataService service = new PlayersDataService(context);
                IEnumerable<Player> players = await service.GetAllPlayers();
                Assert.Equal(2, players.Count());
            }
        }
    }
}



