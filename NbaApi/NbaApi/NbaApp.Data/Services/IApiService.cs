using NbaApp.Data.Models.PlayersModels;
using NbaApp.Data.Models.StatisticsModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NbaApp.Data.Services
{
    public interface IApiService
    {
        IEnumerable<Player> LoadPlayers(string url);
        CareerSummary LoadCareerSummary(string url, int? personId, string urlExtension);
    }
}
