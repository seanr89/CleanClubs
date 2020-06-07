using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Club.API.Controllers;
using Clubs.API.Club.Commands;
using Clubs.API.Club.Queries;
using Clubs.API.Managers.Profiles;
using Clubs.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utilities;

//https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio-code
//https://medium.com/@ducmeit/net-core-using-cqrs-pattern-with-mediatr-part-1-55557e90931b

namespace Clubs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClubsController : ApiController
    {
        private readonly ILogger<ClubsController> _Logger;
        public ClubsController(ILogger<ClubsController> logger)
        {
            _Logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClubListDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetClubsQuery());

            if (result.Any())
                return Ok(result);

            return StatusCode(204, "No Clubs Found");
        }

        /// <summary>
        /// Query a single Club and its details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name="GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetById(Guid id)
        {
            _Logger.LogInformation($"method: {HelperMethods.GetCallerMemberName()}");
            var result = await Mediator.Send(new GetClubQuery() {Id = id});

            if (result != null)
                return Ok(result);

            return StatusCode(204, "No Club Found");
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateClubCommand), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]CreateClubViewModel club)
        {
            _Logger.LogInformation($"method: {HelperMethods.GetCallerMemberName()}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var record = await Mediator.Send(new CreateClubCommand() {Club = club});
            if(record != null)
                return CreatedAtRoute("GetById", new{ id = record}, club);

            return BadRequest("Save failed");
        }
    }
}