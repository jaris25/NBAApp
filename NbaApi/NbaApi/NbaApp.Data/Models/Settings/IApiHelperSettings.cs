using System;
using System.Collections.Generic;
using System.Text;

namespace NbaApp.Data.Models.Settings
{
    public interface IApiHelperSettings
    {
        public string Uri { get; set; }
        public string StatsUri { get; set; }
        public string UriExtension { get; set; }
    }
}
