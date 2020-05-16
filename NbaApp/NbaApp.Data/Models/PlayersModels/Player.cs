using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace NbaApp.Data.Models.PlayersModels
{

    public class Player
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty(PropertyName ="firstName")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "temporaryDisplayName")]
        public string TemporaryDisplayName { get; set; }
        [JsonProperty(PropertyName = "personId")]
        public int PersonId { get; set; }
        [JsonProperty(PropertyName = "TeamId")]
        public int? TeamId { get; set; }
        [JsonProperty(PropertyName = "jersey")]
        public string Jersey { get; set; }
        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }
        [JsonProperty(PropertyName = "pos")]
        public string Pos { get; set; }
        [JsonProperty(PropertyName = "heightFeet")]
        public string HeightFeet { get; set; }
        [JsonProperty(PropertyName = "heightInches")]
        public string HeightInches { get; set; }
        [JsonProperty(PropertyName = "heightMeters")]
        public double? HeightMeters { get; set; }
        [JsonProperty(PropertyName = "weightPounds")]
        public int? WeightPounds { get; set; }
        [JsonProperty(PropertyName = "weightKilograms")]
        public double? WeightKilograms { get; set; }
        [JsonProperty(PropertyName = "dateOfBirthUTC")]
        public string DateOfBirthUTC { get; set; }
        //[JsonProperty(PropertyName = "teams")]
        //public List<Team> Teams { get; set; }
        [JsonProperty(PropertyName = "nbaDebutYear")]
        public string NbaDebutYear { get; set; }
        [JsonProperty(PropertyName = "yearsPro")]
        public int? YearsPro { get; set; }
        [JsonProperty(PropertyName = "collegeName")]
        public string CollegeName { get; set; }
        [JsonProperty(PropertyName = "lastAffiliation")]
        public string LastAffiliation { get; set; }
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
    }
}
