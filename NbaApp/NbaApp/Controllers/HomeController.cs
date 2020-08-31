using Microsoft.AspNetCore.Mvc;
using NbaApp.Data.Models.Filtering;
using NbaApp.Data.Models.StatisticsModels;
using NbaApp.Data.Services;
using NbaApp.Data.Services.FilteringServices;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NbaApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPlayersDataService _playersDataService;
        private readonly FilterEngine _filterEngine;

        public HomeController(IPlayersDataService playersDataService, FilterEngine filterEngine)
        {
            _playersDataService = playersDataService;
            _filterEngine = filterEngine;
        }
        public async Task<IActionResult> Index()
            => View(await _playersDataService.GetAllPlayers());

        [HttpGet]
        public IActionResult FilterStats() => View();

        [HttpPost]
        public async Task<IActionResult> FilterStats(FilterStatsModel filterStatsModel)
        {
            var filteredStats = await _filterEngine.filterStatsCategory(filterStatsModel.StatsCategory, filterStatsModel.ValueToCompare);
            return View("DisplayFilteredStats", filteredStats);
        }

        public async Task<IActionResult> CareerSummaryDetails(int id)
            => View(await _playersDataService.GetCareerSummary(id));

        [HttpPost]
        public async Task<IActionResult> GetPlayerByName(string name)
        {
           
            return View("Index", await _playersDataService.GetPlayersByName(name));
        }
    

        public async Task<IActionResult> RefreshStats()
        {
          //  await _playersDataService.AddAllCareerSummaries();
            return View("Index");
        }
    }
}