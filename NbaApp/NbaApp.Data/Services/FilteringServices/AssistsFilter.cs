using NbaApp.Data.Models.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NbaApp.Data.Services.FilteringServices
{
    public static class AssistsFilter
    {
        public static IEnumerable<DisplayFilteredStatsModel> FilterAssists(string valueToCompare, PlayersContext context)
        {
            var list = new List<DisplayFilteredStatsModel>();
            var display = new DisplayFilteredStatsModel();

            var summaryList = context.CareerSummaries.Where(s => Convert.ToDouble(s.Apg) >= Convert.ToDouble(valueToCompare)).ToList();
            foreach (var item in summaryList)
            {
                display.CareerSummary = item;
                display.Player = item.Player;
                list.Add(display);
            }
            return list;
        }
    }
}
