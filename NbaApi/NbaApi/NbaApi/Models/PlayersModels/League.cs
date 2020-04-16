using Newtonsoft.Json;
using System.Collections.Generic;

namespace NbaApp.Models.PlayersModels
{
    public class League
    {
        [JsonProperty(PropertyName = "standard")]
        public List<Player> Players { get; set; }
    }
}
