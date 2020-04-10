using NbaApp.Models;
using NbaApp.Models.PlayersModels;
using NbaApp.Models.StatisticsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApp.Services
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
        //Map players from api call to database model, check automapper (Entities folder)
        public IEnumerable<Player> getAllPlayers()
        {
            _context.Database.EnsureCreated(); 
            IEnumerable<Player> players = new List<Player>();
            if (_context.Players.Count() == 0)
            {
                players = _apiHelper.loadPlayers(_apiHelperSettings.Uri);
                _context.AddRange(players);
                _context.SaveChanges();
            }
            else
            {
                players = _context.Players.ToList();
            }

            return players;
        }

        public CareerSummary  getCareerSummary(int id)
        {
            var personId = getPersonId(id);
            var summary = _apiHelper.loadCareerSummary(_apiHelperSettings.StatsUri, personId);
            return summary;

        }


        //if property is nullable is it ok to call method like this? I had an error 
        //that the value is null so i had to make them null despite the fact that person id always exists.
        public int? getPersonId(int id)
        {
            var player = _context.Players.SingleOrDefault(p => p.id == id);
            var personId = (int?)player.PersonId;
            return personId;
        }


    }
}
