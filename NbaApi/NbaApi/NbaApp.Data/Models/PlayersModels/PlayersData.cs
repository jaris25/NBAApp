using Newtonsoft.Json;

namespace NbaApp.Data.Models.PlayersModels
{
    public class PlayersData
    {
        [JsonProperty(PropertyName = "league")]
        public League League { get; set; }
    }
}
