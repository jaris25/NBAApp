using NbaApp.Data.Models.Filtering;
using System;
using System.Collections.Generic;
using System.Text;

namespace NbaApp.Data.Services.FilteringServices
{
    public class FilterEngine
    {

        private readonly PlayersContext _context;

        public FilterEngine(PlayersContext context)
        {
            _context = context;
        }

        public IEnumerable<DisplayFilteredStatsModel> filterStatsCategory(StatsCategory category, string valueToCompare)
        { 
            switch (category)
            {
                case StatsCategory.Ppg:
                    return PointsFilter.FilterPoints(valueToCompare, _context);
                case StatsCategory.Apg:
                    return AssistsFilter.FilterAssists(valueToCompare, _context);
            }
            return null;
        }
    }
}
