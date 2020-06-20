

using System;
using Club.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        

        [HttpGet("{id}", Name="AcceptInvite")]
        public IActionResult AcceptInvite(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}", Name="DeclineInvite")]
        public IActionResult DeclineInvite(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}