using NbaApp.Data.Models.Filtering;
using System;
using System.Collections.Generic;
using System.Text;

namespace NbaApp.Data.Services.FilteringServices
{
    public class FilterFactory
    {
        public IFilter GetFilterForStatsCategory(StatsCategory category)
        {
            switch (category)
            {
                case StatsCategory.Ppg:
                    return new PointsFilter();
                case StatsCategory.Apg:
                    return new AssistsFilter();
                case StatsCategory.Rpg:
                    return new ReboundsFilter();
            }
            return null;
        }
    }
}
