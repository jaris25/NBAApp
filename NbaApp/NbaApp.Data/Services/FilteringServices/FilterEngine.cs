using NbaApp.Data.Models.Filtering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NbaApp.Data.Services.FilteringServices
{
    public class FilterEngine
    {

        private readonly PlayersContext _context;

        public FilterEngine(PlayersContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DisplayFilteredStatsModel>> filterStatsCategory(StatsCategory category, string valueToCompare)
        { 
            switch (category)
            {
                case StatsCategory.Ppg:
                    return await PointsFilter.FilterPoints(valueToCompare, _context);
                case StatsCategory.Apg:
                    return await AssistsFilter.FilterAssists(valueToCompare, _context);
                case StatsCategory.Rpg:
                    return await ReboundsFilter.FilterRebounds(valueToCompare, _context);
            }
            return null;
        }
    }
}
