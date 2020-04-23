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
        //This method was used during the first application run to load players to localDb
        public async Task<IEnumerable<Player>> LoadPlayers(string url)
        {
            using (var client = new HttpClient())
            {
                var data = new PlayersData();

                client.BaseAddress = new Uri(url);
                var result = await client.GetAsync("");
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

        public async Task<CareerSummary> LoadCareerSummary(string url, int? personId, string urlExtension)
        {
            using (var client = new HttpClient())
            {
                var data = new StatsData();

                client.BaseAddress = new Uri(url);
                var result = await client.GetAsync(url + personId + urlExtension);
                
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsAsync<StatsData>();
                    
                    var league = readTask.League;
                    var standard = league.Standard;
                    var overalStats = standard.Stats;
                    var summary = overalStats.CareerSummary;

                    return summary;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
