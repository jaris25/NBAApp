using Newtonsoft.Json;

namespace NbaApp.Models.StatisticsModels
{
    public class Total
    {
        [JsonProperty(PropertyName = "ppg")]
        public string Ppg { get; set; }
        [JsonProperty(PropertyName = "rpg")]
        public string Rpg { get; set; }
        [JsonProperty(PropertyName = "apg")]
        public string Apg { get; set; }
        [JsonProperty(PropertyName = "mpg")]
        public string Mpg { get; set; }
        [JsonProperty(PropertyName = "topg")]
        public string Topg { get; set; }
        [JsonProperty(PropertyName = "spg")]
        public string Spg { get; set; }
        [JsonProperty(PropertyName = "bpg")]
        public string Bpg { get; set; }
        [JsonProperty(PropertyName = "tpp")]
        public string Tpp { get; set; }
        [JsonProperty(PropertyName = "ftp")]
        public string Ftp { get; set; }
        [JsonProperty(PropertyName = "fgp")]
        public string Fgp { get; set; }
        [JsonProperty(PropertyName = "assists")]
        public string Assists { get; set; }
        [JsonProperty(PropertyName = "blocks")]
        public string Blocks { get; set; }
        [JsonProperty(PropertyName = "steals")]
        public string Steals { get; set; }
        [JsonProperty(PropertyName = "turnovers")]
        public string Turnovers { get; set; }
        [JsonProperty(PropertyName = "offReb")]
        public string OffReb { get; set; }
        [JsonProperty(PropertyName = "defReb")]
        public string DefReb { get; set; }
        [JsonProperty(PropertyName = "totReb")]
        public string TotReb { get; set; }
        [JsonProperty(PropertyName = "fgm")]
        public string Fgm { get; set; }
        [JsonProperty(PropertyName = "fga")]
        public string Fga { get; set; }
        [JsonProperty(PropertyName = "tpm")]
        public string Tpm { get; set; }
        [JsonProperty(PropertyName = "tpa")]
        public string Tpa { get; set; }
        [JsonProperty(PropertyName = "ftm")]
        public string Ftm { get; set; }
        [JsonProperty(PropertyName = "fta")]
        public string Fta { get; set; }
        [JsonProperty(PropertyName = "Pfouls")]
        public string PFouls { get; set; }
        [JsonProperty(PropertyName = "points")]
        public string Points { get; set; }
        [JsonProperty(PropertyName = "gamesPlayed")]
        public string GamesPlayed { get; set; }
        [JsonProperty(PropertyName = "gamesStarted")]
        public string GamesStarted { get; set; }
        [JsonProperty(PropertyName = "plusMinus")]
        public string PlusMinus { get; set; }
        [JsonProperty(PropertyName = "min")]
        public string Min { get; set; }
        [JsonProperty(PropertyName = "dd2")]
        public string Dd2 { get; set; }
        [JsonProperty(PropertyName = "td3")]
        public string Td3 { get; set; }
    }
}
