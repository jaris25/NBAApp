using NbaApp.Data.Models.PlayersModels;
using NbaApp.Data.Models.StatisticsModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NbaApp.Data.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Player>> LoadPlayers(string url)
        {
            try
            {
                var result = await _httpClient.GetAsync(url);
                var readTask = await result.Content.ReadAsAsync<PlayersData>();
                var league = readTask.League;
                var players = league.Players;

                return players;
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }

        public async Task<CareerSummary> LoadCareerSummary(string url, int personId, string urlExtension)
        {
            try
            {
                var result = await _httpClient.GetAsync(url + personId + urlExtension);
                var readTask = await result.Content.ReadAsAsync<StatsData>();
                var league = readTask.League;
                var standard = league.Standard;
                var overalStats = standard.Stats;
                var summary = overalStats.CareerSummary;
                return summary;
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }
    }
}
