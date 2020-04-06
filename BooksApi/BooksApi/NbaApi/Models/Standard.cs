using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApi.Models
{
    public class Standard
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string temporaryDisplayName { get; set; }
        public int? personId { get; set; }
        public int? teamId { get; set; }
        public string jersey { get; set; }
        public bool isActive { get; set; }
        public string pos { get; set; }
        public string heightFeet { get; set; }
        public string heightInches { get; set; }
        public double? heightMeters { get; set; }
        public int? weightPounds { get; set; }
        public double? weightKilograms { get; set; }
        public string dateOfBirthUTC { get; set; }
        public int? myProperty { get; set; }
        public TeamSite teamSite { get; set; }
        public List<Team> teams { get; set; }
        public Draft draft { get; set; }
        public string nbaDebutYear { get; set; }
        public int? yearsPro { get; set; }
        public string collegeName { get; set; }
        public string lastAffiliation { get; set; }
        public string country { get; set; }
    }
}
