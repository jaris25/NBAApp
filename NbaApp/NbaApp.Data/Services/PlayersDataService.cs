using Microsoft.EntityFrameworkCore;
using NbaApp.Data.Models.PlayersModels;
using NbaApp.Data.Models.StatisticsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApp.Data.Services
{
    public class PlayersDataService : IPlayersDataService
    {
        //TODO: Move api service to console app for database updating!
        private readonly PlayersContext _context;

        public PlayersDataService(PlayersContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(_context));
        }
        //TODO: Add additional layer in services that will be used in home controller
        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            var players = await _context.Players.ToListAsync();
            return players;
        }

        public async Task<CareerSummary> GetCareerSummary(int id)
        {
            var player = _context.Players.Find(id);
            var summary = await _context.CareerSummaries.FirstAsync(s => s.Player == player);
            _context.CareerSummaries.Where(s => s.Player.IsActive==true&& s.Player.FirstName.Contains("a")).Include(s => s.Player).Where(s => s.Player.FirstName.Contains("a")).Select(c => new { c.OffReb, c.pFouls, smth = c.Spg, c.Player}).ToList();
            return summary;
        }

        //public async Task AddAllCareerSummaries()
        //{
        //    var players = _context.Players.ToList();
        //    foreach (var player in players)
        //    {
        //        var personId = player.PersonId;

        //        var summary = await _apiService.LoadCareerSummary(_apiHelperSettings.StatsUri, personId, _apiHelperSettings.UriExtension);
        //        if (summary != null)
        //        {
        //            summary.Player = player;
        //            _context.CareerSummaries.Add(summary);
        //            _context.SaveChanges();
        //        }
        //    }
        //}

        public async Task<IEnumerable<Player>> GetPlayersByName(string name)
        {
            var players = await _context.Players.Where(p => p.LastName.Contains(name) || p.FirstName.Contains(name)).ToListAsync();
            return players;
        }

        public Player GetPlayerById(int id)
        {
            var player = _context.Players.Where(p => p.Id == id).FirstOrDefault();
            return player;
        }

        public void AddPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
