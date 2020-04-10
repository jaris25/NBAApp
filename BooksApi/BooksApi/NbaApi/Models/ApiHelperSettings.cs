using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApp.Models
{
    public class ApiHelperSettings:IApiHelperSettings
    {
        public string Uri { get; set; }
        public string StatsUri { get; set; }
    }
    public interface IApiHelperSettings
    {
        public string Uri { get; set; }
        public string StatsUri { get; set; }
    }
}
