using Newtonsoft.Json;

namespace NbaApp.Data.Models.StatisticsModels
{
    public class StatsData
    {
        [JsonProperty(PropertyName = "league")]
        public League League { get; set; }
    }
}
