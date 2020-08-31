using Microsoft.EntityFrameworkCore;
using NbaApp.Data.Models.Filtering;
using NbaApp.Data.Models.StatisticsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbaApp.Data.Services.FilteringServices
{
    public static class PointsFilter
    {
        public static async Task<IEnumerable<DisplayFilteredStatsModel>> FilterPoints (string valueToCompare, PlayersContext context)
        {
            var list = new List<DisplayFilteredStatsModel>();
            var summaryList = await context.CareerSummaries.Where(s => Convert.ToDouble(s.Ppg) >= Convert.ToDouble(valueToCompare)).ToListAsync();
            populateDisplayList(summaryList, list);
            return list; 
        }

        public static async Task<IEnumerable<DisplayFilteredStatsModel>> FilterTopScorers(PlayersContext context)
        {
            var list = new List<DisplayFilteredStatsModel>();
            var summaryList = await context.CareerSummaries.OrderByDescending(s => s.Ppg).Take(10).ToListAsync();
            populateDisplayList(summaryList, list);
            return list;

        }


        //Another class needed so i could use this one in all filters that i have?
        public static void populateDisplayList(IEnumerable<CareerSummary> summaryList, List<DisplayFilteredStatsModel> displayList)
        {
            foreach (var item in summaryList)
            {
                var display = new DisplayFilteredStatsModel();
                display.CareerSummary = item;
                display.Player = item.Player;
                displayList.Add(display);
            }
        }
    }
}
