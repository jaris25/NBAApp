using NbaApp.Data.Models.Filtering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NbaApp.Data.Services.FilteringServices
{
    public class FilterEngine
    {
        //What solution could i have? I have 10 stats categories, methods are the same except the category I use in Linq to vilter the values.
        private readonly PlayersContext _context;

        public FilterEngine(PlayersContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DisplayFilteredStatsModel>> filterStatsCategory(StatsCategory category, string valueToCompare)
        {
            var factory = new FilterFactory();
            var filter = factory.GetFilterForStatsCategory(category);
            return await filter.FilterStatistics(valueToCompare, _context);
        }
    }
}
