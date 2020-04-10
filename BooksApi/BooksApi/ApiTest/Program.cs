using NbaApp.Models;
using NbaApp.Models.PlayersModels;
using NbaApp.Models.StatisticsModels;
using System;
using System.Linq;
using System.Net.Http;

namespace ApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new StatsData();
            PlayersContext context = new PlayersContext();
            string ppg = null;

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri("http://data.nba.net/data/10s/prod/v1/2016/players/203112_profile.json");
                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<StatsData>();
                    readTask.Wait();
                    data = readTask.Result;
                    var league = data.league;
                    var standard = league.standard;
                    var stats = standard.stats;
                    var summary = stats.careerSummary;
                    ppg = summary.ppg;
                    
                    
                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }
            Console.WriteLine(ppg);

            Console.ReadLine();
        }
    }
}
