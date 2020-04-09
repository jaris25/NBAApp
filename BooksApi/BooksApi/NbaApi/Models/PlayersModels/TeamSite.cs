using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApp.Models.PlayersModels
{
    public class TeamSite
    {
        [Key]
        public Guid Id { get; set; }
        public string playerCode { get; set; }
        public string posFull { get; set; }
        public string displayAffiliation { get; set; }
        public string freeAgentCode { get; set; }
    }
}
