using NbaApp.Data.Models.PlayersModels;
using NbaApp.Data.Models.Settings;
using NbaApp.Data.Models.StatisticsModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApp.Data.Services
{
    public class PlayersDataService
    {
        private readonly PlayersContext _context;
        private IApiService _apiHelper;
        public IApiHelperSettings _apiHelperSettings;

        public PlayersDataService(IApiService apiHelper, IApiHelperSettings apiHelperSettings, PlayersContext context)
        {
            _apiHelper = apiHelper;
            _apiHelperSettings = apiHelperSettings;
            _context = context;
        }
        //TODO: Add additional layer in services that will be used in home controller
        public IEnumerable<Player> getAllPlayers()
        {
            var players = _context.Players.ToList();
            return players;
        }

        public CareerSummary GetCareerSummary(int id)
        {
            var player = _context.Players.First(p => p.id == id);
            var summary = _context.CareerSummaries.First(s => s.Player == player);
            return summary;
        }

        public async Task addAllCareerSummaries()
        {
            var players = _context.Players.ToList();
            foreach (var player in players)
            {
                var personId = player.PersonId;

                var summary = await _apiHelper.LoadCareerSummary(_apiHelperSettings.StatsUri, personId, _apiHelperSettings.UriExtension);
                if (summary != null)
                {
                    summary.Player = player;
                    _context.CareerSummaries.Add(summary);
                    _context.SaveChanges();
                }
            }
        }

        public IEnumerable<Player> GetPlayerByName(string name)
        {
            var players = _context.Players.Where(p => p.LastName == name || p.FirstName == name).ToList();
            return players;
        }


        //if property is nullable is it ok to call method like this? I had an error 
        //that the value is null so i had to make them null despite the fact that person id always exists.
        public int? GetPersonId(int id)
        {
            var player = _context.Players.SingleOrDefault(p => p.id == id);
            var personId = (int?)player.PersonId;
            return personId;
        }


    }
}
