using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApp.Models.StatisticsModels
{
    public class Season
    {
        public int seasonYear { get; set; }
        public List<Team> teams { get; set; }
        public Total total { get; set; }
    }
}
