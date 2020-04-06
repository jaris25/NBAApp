using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NbaApi.Models
{
    public class ApiHelper : IApiHelper
    {
        //public static HttpClient ApiClient { get; set; }

        //public static void initializeClient()
        //{
        //    if (ApiClient == null)
        //    {
        //        ApiClient = new HttpClient();
        //    }
        //    //Create class for api settings and pass the uri to appsettings?
        //    //ApiClient.BaseAddress = new Uri("http://data.nba.net");
        //    ApiClient.DefaultRequestHeaders.Accept.Clear();
        //    ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //}

        public IEnumerable<Standard> loadPlayers(string url)
        {
            using (var client = new HttpClient())
            {
                var data = new Data();
                IEnumerable<Standard> players = new List<Standard>();

                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Data>();
                    readTask.Wait();

                    data = readTask.Result;
                    var league = data.league;
                    players = league.standard;
                    return players;
                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }

        }


        public Standard loadPlayer(string url)
        {
            using (var client = new HttpClient())
            {
                var data = new Data();
                Standard player = new Standard();

                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Data>();
                    readTask.Wait();

                    data = readTask.Result;
                    var league = data.league;
                    var players = league.standard;
                    player = players.Where(p => p.lastName == "Leonard").First();
                    return player;
                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }

        }
    }

    public interface IApiHelper
    {
        static HttpClient ApiClient { get; set; }
        static void initializeClient() { }
        IEnumerable<Standard> loadPlayers(string url);
        Standard loadPlayer(string url);

    }
}
