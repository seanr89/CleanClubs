using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Club.API.Controllers;
using Clubs.Application.Profiles.DTOs.Clubs;
using Clubs.Application.Requests.Club.Commands;
using Clubs.Application.Requests.Club.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utilities;

//https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio-code
//https://medium.com/@ducmeit/net-core-using-cqrs-pattern-with-mediatr-part-1-55557e90931b

namespace Clubs.API.Controllers
{
    [ApiController]
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
        /// <returns>Collection of ClubDTO records</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClubListDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            _Logger.LogInformation($"Club: {HelperMethods.GetCallerMemberName()}");
            var result = await Mediator.Send(new GetClubsQuery());

            if (result.Any())
                return Ok(result);

            return NotFound("No records found");
        }

        /// <summary>
        /// Query a single Club by its Unique ID
        /// </summary>
        /// <param name="id">unique Guid for a club</param>
        /// <returns>A single club record</returns>
        [HttpGet("{id}", Name = "GetClubById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetClubById(Guid id)
        {
            _Logger.LogInformation($"Club: {HelperMethods.GetCallerMemberName()}");
            var result = await Mediator.Send(new GetClubQuery() { Id = id });

            if (result != null)
                return Ok(result);

            return NotFound("No club found");
        }

        #endregion

        #region POST

        /// <summary>
        /// Support the creation of a new Club!
        /// </summary>
        /// <param name="club"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateClubDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateClubDTO club)
        {
            _Logger.LogInformation($"Club: {HelperMethods.GetCallerMemberName()}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var record = await Mediator.Send(new CreateClubCommand() { Club = club });
            if (record != null)
                return CreatedAtRoute("GetClubById", new { id = record }, club);

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
        // [HttpPut("{id}")]
        // [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<IActionResult> UpdateClubDetails(Guid id, [FromBody] ClubUpdateDto club)
        // {
        //     _Logger.LogInformation($"Club: {HelperMethods.GetCallerMemberName()}");
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);

        //     var record = await Mediator.Send(new UpdateClubCommand() { Club = club });
        //     if (record)
        //         return Ok("Club Updated");

        //     return BadRequest("Update failed");
        // }
        #endregion
    }
}