using Newtonsoft.Json;

namespace NbaApp.Models.PlayersModels
{
    public class PlayersData
    {
        [JsonProperty(PropertyName = "league")]
        public League League { get; set; }
    }
}
