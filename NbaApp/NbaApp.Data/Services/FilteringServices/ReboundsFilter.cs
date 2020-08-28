using NbaApp.Data.Models.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NbaApp.Data.Services.FilteringServices
{
    class ReboundsFilter
    {
        public static IEnumerable<DisplayFilteredStatsModel> FilterRebounds(string valueToCompare, PlayersContext context)
        {
            var list = new List<DisplayFilteredStatsModel>();

            var summaryList = context.CareerSummaries.Where(s => Convert.ToDouble(s.Rpg) >= Convert.ToDouble(valueToCompare)).ToList();
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
