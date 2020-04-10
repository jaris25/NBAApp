using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApp.Models.PlayersModels
{
    public class PlayersData
    {
        [JsonProperty(PropertyName = "league")]
        public League League { get; set; }
    }
}
