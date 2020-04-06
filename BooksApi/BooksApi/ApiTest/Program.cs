using NbaApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;


namespace ApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Data();
            Standard player = new Standard();

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri("http://data.nba.net/10s/prod/v1/2019/players.json");
                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Data>();
                    readTask.Wait();

                    data = readTask.Result;
                    var league = data.league;
                    var standard = league.standard;
                    player = standard.Where(p => p.lastName == "Harden").First();
                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }
            Console.WriteLine(player.firstName);

            Console.ReadLine();
        }
    }
}