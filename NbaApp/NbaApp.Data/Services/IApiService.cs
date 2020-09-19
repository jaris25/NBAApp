using NbaApp.Data.Models.PlayersModels;
using NbaApp.Data.Models.StatisticsModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NbaApp.Data.Services
{
    public interface IApiService
    {
        Task<IEnumerable<Player>> LoadPlayers(string url);
        Task<CareerSummary> LoadCareerSummary(string url, int personId, string urlExtension);
        Task AddAllPlayers();
    }
}
