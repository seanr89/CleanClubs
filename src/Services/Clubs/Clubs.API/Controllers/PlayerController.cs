

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Club.API.Controllers;
using Clubs.API.Club.Queries;
using Clubs.API.Managers.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace Clubs.API.Controllers
{
    public class PlayerController : ApiController
    {
        public PlayerController()
        {
            if (Mediator == null)
                throw new ArgumentNullException(nameof(Mediator));
        }


        [HttpGet]
        public async Task<IEnumerable<PlayerDto>> Get()
        {
            return await Mediator.Send(new GetPlayersQuery());
        }
    }
}