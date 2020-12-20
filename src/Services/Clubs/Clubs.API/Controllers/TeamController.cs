using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Club.API.Controllers;
using Clubs.Application.Requests.Club.Commands;
using Utilities;

namespace Clubs.API.Controllers
{
    public class TeamController : ApiController
    {
        private readonly ILogger<TeamController> _Logger;

        public TeamController(ILogger<TeamController> logger)
        {
            _Logger = logger;
        }

        [HttpGet("{id}", Name = "CreateRandomTeamsForMatch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRandomTeamsForMatch(Guid id)
        {
            _Logger.LogInformation($"Teams: {HelperMethods.GetCallerMemberName()}");

            var update = await Mediator.Send(new RandomTeamCreateCommand() { MatchId = id });
            if (update)
                return Ok();
            return BadRequest("Team Generation Failed");
        }
    }
}