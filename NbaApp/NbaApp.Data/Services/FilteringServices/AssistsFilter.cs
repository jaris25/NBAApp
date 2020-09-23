using Microsoft.EntityFrameworkCore;
using NbaApp.Data.Models.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbaApp.Data.Services.FilteringServices
{
    public class AssistsFilter:IFilter
    {
        public async Task<IEnumerable<DisplayFilteredStatsModel>> FilterStatistics(string valueToCompare, PlayersContext context)
        {
            var summaryList = await context.CareerSummaries.Where(s => Convert.ToDouble(s.Apg) >= Convert.ToDouble(valueToCompare))
                .Select(s => new DisplayFilteredStatsModel { Player = s.Player, CareerSummary = s}).ToListAsync();

            return summaryList;
        }
    }
}
