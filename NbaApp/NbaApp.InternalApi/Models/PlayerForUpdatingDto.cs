using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace NbaApp.InternalApi.Models
{
    public class PlayerForUpdatingDto
    {
        [Required]
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
