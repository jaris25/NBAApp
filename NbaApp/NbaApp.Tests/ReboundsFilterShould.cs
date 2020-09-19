using Microsoft.EntityFrameworkCore;
using NbaApp.Data.Models.Filtering;
using NbaApp.Data.Models.StatisticsModels;
using NbaApp.Data.Services;
using NbaApp.Data.Services.FilteringServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NbaApp.Tests
{
    public class ReboundsFilterShould
    {
        //Is this test enough?? This method does not check if display contains Player in it, just checks if we have filtered items.
        [Fact]
        public async Task FilterReboundsAsync()
        {
            var options = new DbContextOptionsBuilder<PlayersContext>()
               .UseInMemoryDatabase(databaseName: "PlayersDatabase")
               .Options;

            using (var context = new PlayersContext(options))
            {
                context.CareerSummaries.Add(new CareerSummary { Rpg = "10" });
                context.CareerSummaries.Add(new CareerSummary { Rpg = "14" });
                context.SaveChanges();
            }
            using (var context = new PlayersContext(options))
            {
                //Why we have such a debil cast? Method returns List of displayStats, why we need to cast this shiet????
                List<DisplayFilteredStatsModel> filteredItems = (List<DisplayFilteredStatsModel>)await ReboundsFilter.FilterRebounds("12", context);
                Assert.Single(filteredItems);
            }
        }
    }
}
