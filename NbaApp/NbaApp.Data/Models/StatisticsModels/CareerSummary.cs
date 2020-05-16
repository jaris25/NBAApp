using NbaApp.Data.Models.PlayersModels;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NbaApp.Data.Models.StatisticsModels
{
    public class CareerSummary
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "tpp")]
        public string Tpp { get; set; }
        [JsonProperty(PropertyName = "ftp")]
        public string Ftp { get; set; }
        [JsonProperty(PropertyName = "fgp")]
        public string Fgp { get; set; }
        [JsonProperty(PropertyName = "ppg")]
        public string Ppg { get; set; }
        [JsonProperty(PropertyName = "rpg")]
        public string Rpg { get; set; }
        [JsonProperty(PropertyName = "apg")]
        public string Apg { get; set; }
        [JsonProperty(PropertyName = "bpg")]
        public string Bpg { get; set; }
        [JsonProperty(PropertyName = "mpg")]
        public string Mpg { get; set; }
        [JsonProperty(PropertyName = "spg")]
        public string Spg { get; set; }
        [JsonProperty(PropertyName = "assists")]
        public string Assists { get; set; }
        [JsonProperty(PropertyName = "blocks")]
        public string Blocks { get; set; }
        [JsonProperty(PropertyName = "steals")]
        public string Steals { get; set; }
        [JsonProperty(PropertyName = "turnovers")]
        public string turnovers { get; set; }
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
        [JsonProperty(PropertyName = "PFouls")]
        public string pFouls { get; set; }
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
        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public Player Player { get; set; }

    }
}
