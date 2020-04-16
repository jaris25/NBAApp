using NbaApp.Data.Models;
using NbaApp.Data.Models.PlayersModels;
using NbaApp.Data.Models.StatisticsModels;
using System.Collections.Generic;
using System.Linq;

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
            var personId = GetPersonId(id);
            var summary = _apiHelper.LoadCareerSummary(_apiHelperSettings.StatsUri, personId, _apiHelperSettings.UriExtension);
            return summary;

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
