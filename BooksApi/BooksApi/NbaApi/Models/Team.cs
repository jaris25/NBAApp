using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApi.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public int SeasonStart { get; set; }
        public int SeasonEnd { get; set; }
    }
}
