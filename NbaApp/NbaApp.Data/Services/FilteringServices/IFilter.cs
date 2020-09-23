using NbaApp.Data.Models.Filtering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NbaApp.Data.Services.FilteringServices
{
    public interface IFilter
    {
        Task<IEnumerable<DisplayFilteredStatsModel>> FilterStatistics(string valueToCompare, PlayersContext context);
    }
}
