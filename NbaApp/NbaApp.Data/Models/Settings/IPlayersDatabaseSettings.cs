using System;
using System.Collections.Generic;
using System.Text;

namespace NbaApp.Data.Models.Settings
{
    public interface IPlayersDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
