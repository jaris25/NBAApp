using Newtonsoft.Json;
using System.Collections.Generic;

namespace NbaApp.Models.StatisticsModels
{
    public class Season
    {
        [JsonProperty(PropertyName = "seasonYear")]
        public int SeasonYear { get; set; }
        [JsonProperty(PropertyName = "teams")]
        public List<Team> Teams { get; set; }
        [JsonProperty(PropertyName = "total")]
        public Total Total { get; set; }
    }
}
