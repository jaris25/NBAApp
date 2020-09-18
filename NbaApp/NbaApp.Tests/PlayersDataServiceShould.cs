using Microsoft.EntityFrameworkCore;
using NbaApp.Data.Models.PlayersModels;
using NbaApp.Data.Models.StatisticsModels;
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
                .UseInMemoryDatabase(databaseName: "PlayersDatabase")
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


        [Fact]
        public async Task GetPlayerByName()
        {
            var options = new DbContextOptionsBuilder<PlayersContext>()
          .UseInMemoryDatabase(databaseName: "PlayersDatabase")
          .Options;
      
            using (var context = new PlayersContext(options))
            {
                var playerMock = new Player { FirstName = "Test" };
                context.Players.Add(playerMock);
                context.Players.Add(new Player { FirstName = "Test1" });
                context.SaveChanges();
                PlayersDataService service = new PlayersDataService(context);
                IEnumerable<Player> players = await service.GetPlayersByName("Test");
                Assert.Contains(playerMock, players);
            }
        }

        [Fact]
        public async Task GetCareerSummary()
        {
            var options = new DbContextOptionsBuilder<PlayersContext>()
                .UseInMemoryDatabase(databaseName: "PlayersDatabase")
                .Options;

            var playerMock = new Player { Id = 1, CollegeName = "Viko" };

            var summary = new CareerSummary { Player = playerMock, PlayerId = 1, Apg = "10" };

            using (var context = new PlayersContext(options))
            {
                context.Players.Add(playerMock);
                context.SaveChanges();
                context.CareerSummaries.Add(summary);
                context.SaveChanges();
            }
            using (var context = new PlayersContext(options))
            {
                PlayersDataService service = new PlayersDataService(context);
                var summaryFromCtxt = await service.GetCareerSummary(1);
                Assert.Equal(summary.Apg, summaryFromCtxt.Apg);
            }
        }
    }
}



