using Microsoft.EntityFrameworkCore;
using NbaApp.Data.Models.Filtering;
using NbaApp.Data.Models.StatisticsModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbaApp.Data.Services.FilteringServices
{
    public class PointsFilter:IFilter
    {
        public async Task<IEnumerable<DisplayFilteredStatsModel>> FilterStatistics(string valueToCompare, PlayersContext context)
        {
            var summaryList = await context.CareerSummaries.Where(s => Convert.ToDouble(s.Ppg) >= Convert.ToDouble(valueToCompare))
                 .Select(s => new DisplayFilteredStatsModel { Player = s.Player, CareerSummary = s }).ToListAsync();
            return summaryList;
        }

        public async Task<IEnumerable<DisplayFilteredStatsModel>> FilterTopScorers(PlayersContext context)
        {
            var summaryList = await context.CareerSummaries.OrderByDescending(s => s.Ppg)
                .Select(s => new DisplayFilteredStatsModel { Player = s.Player, CareerSummary = s }).Take(10).ToListAsync();
            return summaryList;
        }
    }
}
