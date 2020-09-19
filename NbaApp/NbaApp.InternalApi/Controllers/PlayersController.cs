using Microsoft.AspNetCore.Mvc;
using NbaApp.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApp.InternalApi.Controllers
{
    [ApiController]
    public class PlayersController:ControllerBase
    {
        private readonly IPlayersDataService _playersDataService;
        public PlayersController(IPlayersDataService playersDataService)
        {
            _playersDataService = playersDataService;
        }

        [HttpGet("api/players")]
        public JsonResult GetPlayers()
        {
           var players = _playersDataService.GetAllPlayers();
           return new JsonResult(players);
        }
    }
}
