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
    class ReboundsFilter
    {
        public static async Task<IEnumerable<DisplayFilteredStatsModel>> FilterRebounds(string valueToCompare, PlayersContext context)
        {
            var list = new List<DisplayFilteredStatsModel>();

            var summaryList = await context.CareerSummaries.Where(s => Convert.ToDouble(s.Rpg) >= Convert.ToDouble(valueToCompare)).ToListAsync();
            foreach (var item in summaryList)
            {
                var display = new DisplayFilteredStatsModel();
                display.CareerSummary = item;
                display.Player =  context.Players.Where(p => p.Id == item.PlayerId).FirstOrDefault();
                list.Add(display);
            }
            return list;
        }
    }
}
