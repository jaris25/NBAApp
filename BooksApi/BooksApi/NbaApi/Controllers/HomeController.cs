using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NbaApp.Models;
using NbaApp.Services;

namespace NbaApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly PlayersDataService _playersData;

        public HomeController(PlayersDataService playersData)
        {
            _playersData = playersData;
        }
        public IActionResult Index()
        {
            var players = _playersData.getAllPlayers();
            return View(players);
        }

        public IActionResult CareerSummaryDetails(int id)
        {
            var summary = _playersData.getCareerSummary(id);
            return View(summary);
        }
    }
}