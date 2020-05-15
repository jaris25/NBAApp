using System;
using System.Collections.Generic;
using System.Text;

namespace NbaApp.Data.Models.Filtering
{
    public class FilterStatsModel
    {
        public FilterStatsValues FilterStatsValues { get; set; }
        public string ValueToCompare { get; set; }
    }
    public enum FilterStatsValues
    {
        Ppg,
        Rpg,
        Apg,
        Bpg,
        Spg
    }
}
