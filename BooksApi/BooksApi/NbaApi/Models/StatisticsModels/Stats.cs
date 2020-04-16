using Newtonsoft.Json;

namespace NbaApp.Models.StatisticsModels
{
    public class Stats
    {
        [JsonProperty(PropertyName = "latest")]
        public Latest Latest { get; set; }
        [JsonProperty(PropertyName = "careerSummary")]
        public CareerSummary CareerSummary { get; set; }
        [JsonProperty(PropertyName = "regularSeason")]
        public RegularSeason RegularSeason { get; set; }
    }
}
