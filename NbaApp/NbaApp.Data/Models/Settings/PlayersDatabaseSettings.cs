namespace NbaApp.Data.Models.Settings
{
    public class PlayersDatabaseSettings : IPlayersDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
