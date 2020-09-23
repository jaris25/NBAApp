using Microsoft.EntityFrameworkCore;
using NbaApp.Data.Models.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NbaApp.Data.Models.PlayersModels;


namespace NbaApp.Data.Services.FilteringServices
{
    public class ReboundsFilter: IFilter
    {
        public async Task<IEnumerable<DisplayFilteredStatsModel>> FilterStatistics(string valueToCompare, PlayersContext context)
        {
            var summaryList = await context.CareerSummaries.Where(s => Convert.ToDouble(s.Rpg) >= Convert.ToDouble(valueToCompare))
                .Select(s => new DisplayFilteredStatsModel {Player = s.Player, CareerSummary = s}).ToListAsync();

            return summaryList;
        }
    }
}
