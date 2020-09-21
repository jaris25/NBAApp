using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NbaApp.Data.Models.StatisticsModels;
using NbaApp.Data.Services;
using NbaApp.InternalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApp.InternalApi.Controllers
{
    [ApiController]
    [Route("api/players/{playerId}/careersummary")]
    public class CareerSummaryController: ControllerBase
    {

        private readonly IPlayersDataService _playersDataService;
        private readonly IMapper _mapper;

        public CareerSummaryController(IPlayersDataService playersDataService, IMapper mapper)
        {
            _playersDataService = playersDataService ?? throw new ArgumentNullException(nameof(playersDataService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task <IActionResult> GetCareerSummary(int playerId)
        {
            var summary =  await _playersDataService.GetCareerSummary(playerId);
            if(summary == null)
            {
                return NotFound();
            }
          
            return Ok(_mapper.Map<SummaryDto>(summary));
        }
    }
}
