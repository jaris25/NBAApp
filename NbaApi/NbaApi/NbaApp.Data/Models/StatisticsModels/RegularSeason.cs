using Newtonsoft.Json;
using System.Collections.Generic;

namespace NbaApp.Data.Models.StatisticsModels
{
    public class RegularSeason
    {
        [JsonProperty(PropertyName = "season")]
        public List<Season> Season { get; set; }
    }
}
