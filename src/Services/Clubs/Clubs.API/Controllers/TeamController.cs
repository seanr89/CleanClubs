

using System;
using System.Threading.Tasks;
using Club.API.Controllers;
using Clubs.Application.Business;
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
        private readonly ITeamGenerator _TeamGenerator;

        public TeamController(ILogger<TeamController> logger, ITeamGenerator teamGenerator)
        {
            _Logger = logger;
            _TeamGenerator = teamGenerator;
        }

        [HttpGet("{id}", Name = "CreateTeamsForMatch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTeamsForMatch(Guid id)
        {
            _Logger.LogInformation($"Teams: {HelperMethods.GetCallerMemberName()}");

            var match = await Mediator.Send(new GetMatchQuery() { MatchId = id });

            if (match != null)
            {
                var updatedMatch = await _TeamGenerator.Generate(new GenerationInfo()
                { Match = match, GeneratorOption = GeneratorType.Random });

                var update = await Mediator.Send(new UpdateMatchCommand() { Match = updatedMatch });
                if (update)
                    return Ok();
                return BadRequest();
            }
            return BadRequest("Unable to find match!");
        }
    }
}