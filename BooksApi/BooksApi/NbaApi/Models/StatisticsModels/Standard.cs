﻿using Newtonsoft.Json;

namespace NbaApp.Models.StatisticsModels
{
    public class Standard
    {
        [JsonProperty(PropertyName = "teamId")]
        public string TeamId { get; set; }
        [JsonProperty(PropertyName = "stats")]
        public Stats Stats { get; set; }
    }
}
