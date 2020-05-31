

using System;
using System.Threading.Tasks;
using Club.API.Controllers;
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
        public async Task<IActionResult> Get()
        {
            throw new NotImplementedException();
        }
    }
}