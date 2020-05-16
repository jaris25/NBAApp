namespace NbaApp.Data.Models.Settings
{
    public class ApiHelperSettings:IApiHelperSettings
    {
        public string Uri { get; set; }
        public string StatsUri { get; set; }
        public string UriExtension { get; set; }
    }
}
