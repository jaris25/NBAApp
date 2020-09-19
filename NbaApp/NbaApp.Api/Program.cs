using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NbaApp.Data.Models.PlayersModels;
using NbaApp.Data.Models.Settings;
using NbaApp.Data.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NbaApp.Api
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            ApiHelperSettings api = new ApiHelperSettings();
            var collection = new ServiceCollection();
            collection.AddScoped<DbContext, PlayersContext>();
            // ...
            // Add other services
            // ...
            var serviceProvider = collection.BuildServiceProvider();
            var context = serviceProvider.GetService<PlayersContext>();
            ApiService apiService = new ApiService(httpClient, context, api);
            await apiService.AddAllPlayers();

        }
    }
}
