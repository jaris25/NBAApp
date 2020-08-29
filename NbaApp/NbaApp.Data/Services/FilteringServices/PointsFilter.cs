using Microsoft.EntityFrameworkCore;
using NbaApp.Data.Models.Filtering;
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
            foreach (var item in summaryList)
            {
                var display = new DisplayFilteredStatsModel();
                display.CareerSummary = item;
                display.Player = item.Player;
                list.Add(display);
            }
            return list; 
        }
    }
}
