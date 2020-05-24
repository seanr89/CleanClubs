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

        public IActionResult Get()
        {

        }

        public IActionResult GetById()
        {
            
        }
    }
}