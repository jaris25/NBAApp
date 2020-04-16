using Newtonsoft.Json;
using System.Collections.Generic;

namespace NbaApp.Data.Models.PlayersModels
{
    public class League
    {
        [JsonProperty(PropertyName = "standard")]
        public List<Player> Players { get; set; }
    }
}
