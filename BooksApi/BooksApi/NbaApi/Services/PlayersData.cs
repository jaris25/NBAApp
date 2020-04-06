using NbaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApi.Services
{
    public class PlayersData
    {
        private readonly PlayersContext _context;
        private ApiHelper _apiHelper;
        public IApiHelperSettings _apiHelperSettings;
       
        public  PlayersData(ApiHelper apiHelper, IApiHelperSettings apiHelperSettings, PlayersContext context)
        {
            _apiHelper = apiHelper;
            _apiHelperSettings = apiHelperSettings;
            _context = context;
        }
    
        public IEnumerable<Standard> getAllPlayers()
        {
            IEnumerable<Standard> players = new List<Standard>();
            if (_context.Players.Count() == 0)
            {
                players = _apiHelper.loadPlayers(_apiHelperSettings.Uri);
                _context.Add(players);
            }
            else
            {
                players = _context.Players.ToList();
            }

            return players;
        }
    }
}
