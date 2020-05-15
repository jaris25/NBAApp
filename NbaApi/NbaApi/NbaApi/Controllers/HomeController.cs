using Microsoft.AspNetCore.Mvc;
using NbaApp.Data.Models.Filtering;
using NbaApp.Data.Models.StatisticsModels;
using NbaApp.Data.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
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

        [HttpGet]
        public IActionResult FilterStats() => View();

        [HttpPost]
        public IActionResult FilterStats(FilterStatsModel filterStatsModel)
        {
            var filteredStats = _playersDataService.FilterStats(filterStatsModel.FilterStatsValues, filterStatsModel.ValueToCompare);
            //TempData["FilterStatsModel"] = JsonConvert.SerializeObject(filteredStats);
            TempData.Put("Key", filteredStats);
            //TempData["FilterStatsModel"] = filteredStats;
            return RedirectToAction("DisplayFilteredStats");
        }
        
        //The value is not passed to the model.
        public IActionResult DisplayFilteredStats()
        {
            var model = TempData.Get<IEnumerable<DisplayFilteredStatsModel>>("Key");

            //var modelis = JsonConvert.DeserializeObject<List<DisplayFilteredStatsModel>>(TempData["FilterStatsModel"]);
            return View(model);
        }

        public async Task<IActionResult> CareerSummaryDetails(int id)
            => View(await _playersDataService.GetCareerSummary(id));

        public async Task<IActionResult> GetPlayerByName(string playerName)
            => View(await _playersDataService.GetPlayersByName(playerName));

    }
}