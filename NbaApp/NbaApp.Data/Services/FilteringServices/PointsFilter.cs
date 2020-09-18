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
            var summaryList = await context.CareerSummaries.Where(s => Convert.ToDouble(s.Ppg) >= Convert.ToDouble(valueToCompare)).ToListAsync();
            var filteredList = populateDisplayList(summaryList);
            return filteredList;
        }

        public static async Task<IEnumerable<DisplayFilteredStatsModel>> FilterTopScorers(PlayersContext context)
        {
            var summaryList = await context.CareerSummaries.OrderByDescending(s => s.Ppg).Take(10).ToListAsync();
            return populateDisplayList(summaryList);
        }


        //Another class needed so i could use this one in all filters that i have?
        public static IEnumerable<DisplayFilteredStatsModel> populateDisplayList(IEnumerable<CareerSummary> summaryList)
        {
            var displayList = new List<DisplayFilteredStatsModel>();
            foreach (var item in summaryList)
            {
                var display = new DisplayFilteredStatsModel();
                display.CareerSummary = item;
                display.Player = item.Player;
                displayList.Add(display);
            }
            return displayList;
        }
    }
}
