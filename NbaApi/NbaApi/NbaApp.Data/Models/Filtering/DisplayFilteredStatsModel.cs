using NbaApp.Data.Models.PlayersModels;
using NbaApp.Data.Models.StatisticsModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NbaApp.Data.Models.Filtering
{
    public class DisplayFilteredStatsModel
    {
        public Player Player { get; set; }
        public CareerSummary CareerSummary { get; set; }

    }
}
