

using System;
using System.Threading.Tasks;
using Club.API.Controllers;
using Clubs.Application.Business;
using Clubs.Application.Profiles.Dto;
using Clubs.Application.Requests.Matches.Commands;
using Clubs.Application.Requests.Matches.Queries;
using Clubs.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utilities;

namespace Clubs.API.Controllers
{
    [ApiController]
    public class TeamController : ApiController
    {
        private readonly ILogger<TeamController> _Logger;
        private readonly GenerationService _generationService;

        public TeamController(ILogger<TeamController> logger, GenerationService generationService)
        {
            _Logger = logger;
            _generationService = generationService;
        }

        [HttpGet("{id}", Name = "CreateRandomTeamsForMatch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRandomTeamsForMatch(Guid id)
        {
            _Logger.LogInformation($"Teams: {HelperMethods.GetCallerMemberName()}");

            var update = await _generationService.ExecuteTeamGenerationForMatchAndUpdate(id, GeneratorType.Random);
            if (update)
                return Ok();
            return BadRequest("Team Generation Failed");
        }

        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<IActionResult> UpdateMatchTeamsManual(MatchDto match)
        // {
        //     throw new NotImplementedException();
        // }
    }
}