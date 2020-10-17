

using System;
using System.Threading.Tasks;
using Club.API.Controllers;
using Clubs.Application.Profiles.DTO;
using Clubs.Application.Requests.Invite.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utilities;

namespace Clubs.API.Controllers
{
    [ApiController]
    public class InviteController : ApiController
    {
        private readonly ILogger<InviteController> _Logger;
        public InviteController(ILogger<InviteController> logger)
        {
            _Logger = logger;
        }

        [HttpGet("{id}", Name = "AcceptInvite")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AcceptInvite(Guid id)
        {
            _Logger.LogInformation($"Invite: {HelperMethods.GetCallerMemberName()}");

            var invite = new InviteDTO() { Id = id, Accepted = true };
            var record = await Mediator.Send(new UpdateInviteCommand() { Invite = invite });
            if (record)
                return Ok("Record Updated!");

            return BadRequest();
        }

        [HttpGet("{id}", Name = "DeclineInvite")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeclineInvite(Guid id)
        {
            _Logger.LogInformation($"Invite: {HelperMethods.GetCallerMemberName()}");

            var invite = new InviteDTO() { Id = id, Accepted = false };
            var record = await Mediator.Send(new UpdateInviteCommand() { Invite = invite });
            if (record)
                return Ok("Record Updated!");
            return BadRequest();
        }
    }
}