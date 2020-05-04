using Microsoft.AspNetCore.Mvc;
using NbaApp.Data.Services;
using System.Threading.Tasks;

namespace NbaApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPlayersDataService _playersDataService;

        public HomeController(IPlayersDataService playersDataService)
        {
            _playersDataService = playersDataService;
        }
        public async Task<IActionResult> Index()
            => View(await _playersDataService.GetAllPlayers());

        public async Task<IActionResult> CareerSummaryDetails(int id)
            => View(await _playersDataService.GetCareerSummary(id));


        public async Task<IActionResult> GetPlayerByName(string playerName)
            => View(await _playersDataService.GetPlayersByName(playerName));

    }
}