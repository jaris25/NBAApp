using Microsoft.EntityFrameworkCore;
using NbaApp.Data.Models.Filtering;
using NbaApp.Data.Models.PlayersModels;
using NbaApp.Data.Models.Settings;
using NbaApp.Data.Models.StatisticsModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApp.Data.Services
{
    public class PlayersDataService : IPlayersDataService
    {
        private readonly PlayersContext _context;
        private readonly IApiService _apiService;
        private readonly IApiHelperSettings _apiHelperSettings;

        public PlayersDataService(IApiService apiService, IApiHelperSettings apiHelperSettings, PlayersContext context)
        {
            _apiService = apiService;
            _apiHelperSettings = apiHelperSettings;
            _context = context;
        }
        //TODO: Add additional layer in services that will be used in home controller
        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            var players = await _context.Players.ToListAsync();
            return players;

        }

        public async Task<CareerSummary> GetCareerSummary(int id)
        {
            var player = _context.Players.First(p => p.Id == id);
            var summary = await _context.CareerSummaries.FirstAsync(s => s.Player == player);
            return summary;
        }

        public async Task AddAllCareerSummaries()
        {
            var players = _context.Players.ToList();
            foreach (var player in players)
            {
                var personId = player.PersonId;

                var summary = await _apiService.LoadCareerSummary(_apiHelperSettings.StatsUri, personId, _apiHelperSettings.UriExtension);
                if (summary != null)
                {
                    summary.Player = player;
                    _context.CareerSummaries.Add(summary);
                    _context.SaveChanges();
                }
            }
        }

        public async Task<IEnumerable<Player>> GetPlayersByName(string name)
        {
            var players = await _context.Players.Where(p => p.LastName == name || p.FirstName == name).ToListAsync();
            return players;
        }

        //public IEnumerable<DisplayFilteredStatsModel> FilterStats(StatsCategory parameter, string valueToCompare)
        //{
        //    var list = new List<DisplayFilteredStatsModel>();
        //    var display = new DisplayFilteredStatsModel();

        //    switch (parameter)
        //    {
        //        case StatsCategory.Apg:
        //            {
        //                var summaryList = _context.CareerSummaries.Where(s => Convert.ToDouble(s.Apg) >= Convert.ToDouble(valueToCompare)).ToList();
        //                foreach (var item in summaryList)
        //                {
        //                    display.CareerSummary = item;
        //                    display.Player = item.Player;
        //                    list.Add(display);
        //                }
        //                break;

        //            }
        //        case StatsCategory.Ppg:
        //            {
        //                var summaryList = _context.CareerSummaries.Where(s => Convert.ToDouble(s.Ppg) >= Convert.ToDouble(valueToCompare));
        //                foreach (var item in summaryList)
        //                {
        //                    display.CareerSummary = item;
        //                    display.Player = item.Player;
        //                    list.Add(display);
        //                }
        //                break;
        //            }
        //        case StatsCategory.Rpg:
        //            {
        //                var summaryList = _context.CareerSummaries.Where(s => Convert.ToDouble(s.Rpg) >= Convert.ToDouble(valueToCompare));
        //                foreach (var item in summaryList)
        //                {
        //                    display.CareerSummary = item;
        //                    display.Player = item.Player;
        //                    list.Add(display);
        //                }
        //                break;
        //            }
        //        case StatsCategory.Spg:
        //            {
        //                var summaryList = _context.CareerSummaries.Where(s => Convert.ToDouble(s.Spg) >= Convert.ToDouble(valueToCompare));
        //                foreach (var item in summaryList)
        //                {
        //                    display.CareerSummary = item;
        //                    display.Player = item.Player;
        //                    list.Add(display);
        //                }
        //                break;
        //            }
        //    }
        //    return list;

        //}
    }
}
