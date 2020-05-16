using NbaApp.Data.Models.Filtering;
using NbaApp.Data.Models.PlayersModels;
using NbaApp.Data.Models.StatisticsModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NbaApp.Data.Services
{
    public interface IPlayersDataService
    {
        Task<IEnumerable<Player>> GetAllPlayers() ;
        Task<CareerSummary> GetCareerSummary(int id);
        Task<IEnumerable<Player>> GetPlayersByName(string name);
        public IEnumerable<DisplayFilteredStatsModel> FilterStats(FilterStatsValues values, string value);


    }
}
