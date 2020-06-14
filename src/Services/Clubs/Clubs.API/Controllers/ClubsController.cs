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
    //[Route("api/[controller]/[action]")]
    public class ClubsController : ApiController
    {
        private readonly ILogger<ClubsController> _Logger;
        public ClubsController(ILogger<ClubsController> logger)
        {
            _Logger = logger;
        }

        #region GET

        /// <summary>
        /// Query all clubs
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
        /// Query a single Club by its Unique ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name="GetClubById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetClubById(Guid id)
        {
            _Logger.LogInformation($"method: {HelperMethods.GetCallerMemberName()}");
            var result = await Mediator.Send(new GetClubQuery() {Id = id});

            if (result != null)
                return Ok(result);

            return StatusCode(204, "No Club Found");
        }

        #endregion

        #region POST

        [HttpPost]
        [ProducesResponseType(typeof(CreateClubViewModel), StatusCodes.Status201Created)]
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
                return CreatedAtRoute("GetClubById", new{ id = record}, club);

            return BadRequest("Save failed");
        }

        #endregion

        #region PUT/UPDATE

        /// <summary>
        /// Support the updating of club details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="club"></param>
        /// <returns></returns>
        [HttpPut("{id}", Name="UpdateClubDetails")]  
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, [FromBody]ClubUpdateDto club)
        {
            _Logger.LogInformation($"method: {HelperMethods.GetCallerMemberName()}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var record = await Mediator.Send(new UpdateClubCommand() {Club = club});
            if(record)
                return Ok("Club Updated!");

            return BadRequest("Save failed");
        }

        #endregion
    }
}