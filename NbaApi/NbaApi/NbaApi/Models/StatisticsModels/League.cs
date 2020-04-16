using Newtonsoft.Json;

namespace NbaApp.Models.StatisticsModels
{
    public class League
    {
        [JsonProperty(PropertyName = "standard")]
        public  Standard Standard { get; set; }
    }
}
