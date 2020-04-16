namespace NbaApp.Data.Models
{
    public class ApiHelperSettings:IApiHelperSettings
    {
        public string Uri { get; set; }
        public string StatsUri { get; set; }
        public string UriExtension { get; set; }
    }
    public interface IApiHelperSettings
    {
        public string Uri { get; set; }
        public string StatsUri { get; set; }
        public string UriExtension { get; set; }
    }
}
