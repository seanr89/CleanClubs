

using System;
using System.Threading.Tasks;
using Club.API.Controllers;
using Clubs.Application.Requests.Matches.Queries;
using Clubs.Domain.Enums;
using Clubs.Generator;
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
        private readonly TeamGenerator _TeamGenerator;

        public TeamController(ILogger<TeamController> logger, TeamGenerator teamGenerator)
        {
            _Logger = logger;
            _TeamGenerator = teamGenerator;
        }

        [HttpGet("{id}", Name="CreateTeamsForMatch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTeamsForMatch(Guid id)
        {
            _Logger.LogInformation($"Team: {HelperMethods.GetCallerMemberName()}");

            var match = await Mediator.Send(new GetMatchQuery() {MatchId = id});

            if(match != null)
            {
                _TeamGenerator.Generate(new GenerationInfo() { Invites = match.Invites, GeneratorOption = GeneratorType.Random });
            }

            return Ok(match);

            return BadRequest();
        }
    }
}