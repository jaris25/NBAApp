using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApp.Models.StatisticsModels
{
    public class Stats
    {
        public Latest latest { get; set; }
        public CareerSummary careerSummary { get; set; }
        public RegularSeason regularSeason { get; set; }
    }
}
