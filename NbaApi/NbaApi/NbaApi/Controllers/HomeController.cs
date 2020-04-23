using Microsoft.AspNetCore.Mvc;
using NbaApp.Data.Services;
using System.Threading.Tasks;

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
            => View(_playersData.GetCareerSummary(id));


        public IActionResult GetPlayerByName(string playerName)
        {
            var player = _playersData.GetPlayerByName(playerName);
            return View(player);
        }
    }
}