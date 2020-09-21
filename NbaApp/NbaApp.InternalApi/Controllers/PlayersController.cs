using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NbaApp.Data.Models.PlayersModels;
using NbaApp.Data.Services;
using NbaApp.InternalApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NbaApp.InternalApi.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayersController:ControllerBase
    {
        private readonly IPlayersDataService _playersDataService;
        private readonly IMapper _mapper;
        
        public PlayersController(IPlayersDataService playersDataService, IMapper mapper)
        {
            _playersDataService = playersDataService?? throw new ArgumentNullException(nameof(playersDataService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task <IActionResult> GetPlayers()
        {
           var players = await _playersDataService.GetAllPlayers();
            return Ok(_mapper.Map<IEnumerable<PlayerDto>>(players));
            //return Ok(players);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlayer(int id)
        {
            var player = _playersDataService.GetPlayerById(id);
            if(player == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PlayerDto>(player));
        }

        [HttpPost]
        public IActionResult AddPlayer([FromBody]PlayerForCreationDto playerForCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var player = _mapper.Map<Player>(playerForCreation);
            _playersDataService.AddPlayer(player);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePlayer(int id, [FromBody]PlayerForUpdatingDto playerForUpdating)
        {
            var player = _playersDataService.GetPlayerById(id);
            if (player == null)
            {
                return NotFound();
            }

            _mapper.Map(playerForUpdating, player);
            _playersDataService.Save();
            
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdatePlayer(int id, [FromBody]JsonPatchDocument<PlayerForUpdatingDto> patchDoc)
        {
            var playerFromStore =  _playersDataService.GetPlayerById(id);
            if(playerFromStore == null)
            {
                return NotFound();
            }
            var playerToPatch = _mapper.Map<PlayerForUpdatingDto>(playerFromStore);

            patchDoc.ApplyTo(playerToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _mapper.Map(playerToPatch, playerFromStore);
            _playersDataService.Save();
            
            return Ok();
        }
    }
}
