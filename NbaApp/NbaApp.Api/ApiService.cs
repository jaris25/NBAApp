using NbaApp.Data.Models.PlayersModels;
using NbaApp.Data.Models.Settings;
using NbaApp.Data.Models.StatisticsModels;
using NbaApp.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NbaApp.Api
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly PlayersContext _context;
        private readonly IApiHelperSettings _apiHelperSettings;

        public ApiService(HttpClient httpClient, PlayersContext playersContext, IApiHelperSettings apiHelperSettings)
        {
            _httpClient = httpClient;
            _context = playersContext;
            _apiHelperSettings = apiHelperSettings;

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

        public async Task AddAllPlayers()
        {
            var players = await LoadPlayers(_apiHelperSettings.Uri);
            _context.Players.Add((Player)players);
            _context.SaveChanges();
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

        public async Task AddAllCareerSummaries()
        {
            var players = _context.Players.ToList();
            foreach (var player in players)
            {
                var personId = player.PersonId;

                var summary = await LoadCareerSummary(_apiHelperSettings.StatsUri, personId, _apiHelperSettings.UriExtension);
                if (summary != null)
                {
                    summary.Player = player;
                    _context.CareerSummaries.Add(summary);
                    _context.SaveChanges();
                }
            }
        }

    }
}
