using System;
using Microsoft.AspNetCore.Mvc;

namespace Clubs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ClubsController : ControllerBase
    {
        public ClubsController()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}