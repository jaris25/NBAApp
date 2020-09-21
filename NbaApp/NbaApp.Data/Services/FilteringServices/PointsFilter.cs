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
    public static class PointsFilter
    {
        public static async Task<IEnumerable<DisplayFilteredStatsModel>> FilterPoints (string valueToCompare, PlayersContext context)
        {
            var summaryList = await context.CareerSummaries.Where(s => Convert.ToDouble(s.Ppg) >= Convert.ToDouble(valueToCompare))
                .Select(s => new DisplayFilteredStatsModel { Player = s.Player, CareerSummary = s }).ToListAsync();
            return summaryList;
        }

        public static async Task<IEnumerable<DisplayFilteredStatsModel>> FilterTopScorers(PlayersContext context)
        {
            var summaryList = await context.CareerSummaries.OrderByDescending(s => s.Ppg)
                .Select(s => new DisplayFilteredStatsModel { Player = s.Player, CareerSummary = s }).Take(10).ToListAsync();
            return summaryList;
        }
    }
}
