using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApi.Models
{
    public class TeamSite
    {
        public string playerCode { get; set; }
        public string posFull { get; set; }
        public string displayAffiliation { get; set; }
        public string freeAgentCode { get; set; }
    }
}
