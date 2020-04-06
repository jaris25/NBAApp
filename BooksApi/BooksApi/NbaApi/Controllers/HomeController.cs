using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NbaApi.Models;
using NbaApi.Services;

namespace NbaApi.Controllers
{
    public class HomeController : Controller
    {

        private readonly PlayersData _playersData;

        public HomeController(PlayersData playersData)
        {
            _playersData = playersData;
        }
        public IActionResult Index()
        {
            var players = _playersData.getAllPlayers();
            return View(players);
        }
    }
}