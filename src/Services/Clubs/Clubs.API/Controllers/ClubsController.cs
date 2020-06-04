using System;
using System.Linq;
using System.Threading.Tasks;
using Club.API.Controllers;
using Clubs.API.Club.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

//https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio-code
//https://medium.com/@ducmeit/net-core-using-cqrs-pattern-with-mediatr-part-1-55557e90931b

namespace Clubs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClubsController : ApiController
    {
        private readonly ILogger<ClubsController> _logger;
        public ClubsController(ILogger<ClubsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetClubsQuery());

            if (result.Any())
                return Ok(result);

            return StatusCode(204, "No Clubs Found");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await Mediator.Send(new GetClubQuery() {Id = id});

            if (result != null)
                return Ok(result);

            return StatusCode(204, "No Club Found");
        }
    }
}