using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApp.Models.PlayersModels
{
    public class Team
    {
        public int TeamId { get; set; }
        public int SeasonStart { get; set; }
        public int SeasonEnd { get; set; }
    }
}
