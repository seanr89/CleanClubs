

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


        public async Task<IActionResult> GetTask()
        {
            throw new NotImplementedException();
        }
    }
}