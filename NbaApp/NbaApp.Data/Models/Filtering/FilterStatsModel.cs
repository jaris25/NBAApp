using System;
using System.Collections.Generic;
using System.Text;

namespace NbaApp.Data.Models.Filtering
{
    public class FilterStatsModel
    {
        public StatsCategory StatsCategory { get; set; }
        public string ValueToCompare { get; set; }
    }
    public enum StatsCategory
    {
        Ppg,
        Rpg,
        Apg,
        Bpg,
        Spg
    }
}
