

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Club.API.Controllers;
using Clubs.API.Club.Queries;
using Clubs.API.Managers.Profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Clubs.API.Controllers
{
    public class MemberController : ApiController
    {
        private readonly ILogger<MemberController> _logger;
        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
        }


        // [HttpGet]
        // public async Task<IEnumerable<PlayerDto>> Get()
        // {
        //     return await Mediator.Send(new GetPlayersQuery());
        // }
    }
}