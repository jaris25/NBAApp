using Microsoft.AspNetCore.Mvc;
using NbaApp.Data.Services;

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
            var summary = _playersData.GetCareerSummary(id);
            return View(summary);
        }
    }
}