using NbaApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApp.Models.PlayersModels
{
    public class League
    {
        [JsonProperty(PropertyName = "standard")]
        public List<Player> Players { get; set; }
    }
}
