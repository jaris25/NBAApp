using Newtonsoft.Json;

namespace NbaApp.Models.StatisticsModels
{
    public class StatsData
    {
        [JsonProperty(PropertyName = "league")]
        public League League { get; set; }
    }
}
