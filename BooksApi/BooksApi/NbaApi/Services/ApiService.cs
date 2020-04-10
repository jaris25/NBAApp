using NbaApp.Models.PlayersModels;
using NbaApp.Models.StatisticsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NbaApp.Services
{
    public class ApiService : IApiService
    {

        public IEnumerable<Player> loadPlayers(string url)
        {
            using (var client = new HttpClient())
            {
                var data = new PlayersData();
                IEnumerable<Player> players = new List<Player>();

                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PlayersData>();
                    readTask.Wait();

                    data = readTask.Result;
                    var league = data.League;
                    players = league.Players;

                    return players;
                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }

        }

        public CareerSummary loadCareerSummary(string url, int? personId)
        {
            using (var client = new HttpClient())
            {
                var data = new StatsData();
                IEnumerable<CareerSummary> statistics = new List<CareerSummary>();

                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync(url + personId + "_profile.json");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<StatsData>();
                    readTask.Wait();

                    data = readTask.Result;
                    var league = data.league;
                    var standard = league.standard;
                    var overalStats = standard.stats;
                    var summary = overalStats.careerSummary;
                    
                    return summary;
                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }
        }

    }

    public interface IApiService
    {
        static HttpClient ApiClient { get; set; }
        IEnumerable<Player> loadPlayers(string url);
        CareerSummary loadCareerSummary(string url, int? personId);

    }
}
