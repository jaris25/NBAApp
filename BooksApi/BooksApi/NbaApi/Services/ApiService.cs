using NbaApp.Models.PlayersModels;
using NbaApp.Models.StatisticsModels;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace NbaApp.Services
{
    public class ApiService : IApiService
    {

        public IEnumerable<Player> LoadPlayers(string url)
        {
            using (var client = new HttpClient())
            {
                var data = new PlayersData();

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
                    var players = league.Players;

                    return players;
                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }

        }

        public CareerSummary LoadCareerSummary(string url, int? personId, string urlExtension)
        {
            using (var client = new HttpClient())
            {
                var data = new StatsData();

                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync(url + personId + urlExtension);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<StatsData>();
                    readTask.Wait();

                    data = readTask.Result;
                    var league = data.League;
                    var standard = league.Standard;
                    var overalStats = standard.Stats;
                    var summary = overalStats.CareerSummary;

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
        //static HttpClient ApiClient { get; set; }
        IEnumerable<Player> LoadPlayers(string url);
        CareerSummary LoadCareerSummary(string url, int? personId, string urlExtension);

    }
}
