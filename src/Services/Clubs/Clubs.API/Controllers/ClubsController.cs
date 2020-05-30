using System;
using System.Linq;
using System.Threading.Tasks;
using Club.API.Controllers;
using Clubs.API.Club.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Clubs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ClubsController : ApiController
    {
        public ClubsController()
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetClubsQuery());

            if (result.Any())
                return Ok(result);

            return StatusCode(222, "No Clubs Found");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}