using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Club.API.Controllers;
using Clubs.Application;
using Clubs.Application.Business;
using Clubs.Application.Profiles.DTO;
using Clubs.Application.Requests.Matches.Queries;
using Clubs.Application.Requests.Matches.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utilities;

namespace Clubs.API.Controllers
{
    public class MatchController : ApiController
    {
        private readonly ILogger<MatchController> _Logger;
        private readonly MatchManager _MatchManager;
        public MatchController(ILogger<MatchController> logger, MatchManager manager)
        {
            _Logger = logger;
            _MatchManager = manager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MatchListDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            _Logger.LogInformation($"Matches: {HelperMethods.GetCallerMemberName()}");
            var result = await Mediator.Send(new GetMatchesQuery());
            if (result.Any())
                return Ok(result);

            return NoContent();
        }

        /// <summary>
        /// Query a single, detailed, match record by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetMatchById")]
        [ProducesResponseType(typeof(MatchDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetMatchById(Guid id)
        {
            _Logger.LogInformation($"Matches: {HelperMethods.GetCallerMemberName()}");
            var result = await Mediator.Send(new GetMatchQuery() { MatchId = id });

            if (result != null)
                return Ok(result);

            return NoContent();
        }

        /// <summary>
        /// Query all exisiting matches for an individual club!
        /// </summary>
        /// <param name="id">the Unique club record</param>
        /// <returns>A collection of MatchList records</returns>
        [HttpGet("{id}", Name = "GetMatchesByClubId")]
        [ProducesResponseType(typeof(IEnumerable<MatchDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetMatchesByClubId(Guid id)
        {
            _Logger.LogInformation($"Matches: {HelperMethods.GetCallerMemberName()}");
            var result = await Mediator.Send(new GetClubMatchesQuery() { ClubId = id });

            if (result.Any())
                return Ok(result);

            return NoContent();
        }

        #region POST

        /// <summary>
        /// Support the creation of a match record and handle invitations
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateMatchDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateMatchWithInvites([FromBody] CreateMatchDTO match)
        {
            _Logger.LogInformation($"Matches: {HelperMethods.GetCallerMemberName()}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await Mediator.Send(new CreateMatchWithInvitesCommand() { Match = match });
                if (result != null)
                    return CreatedAtRoute("GetMatchById", new { id = result }, match);

                return BadRequest("Save failed");
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Something went wrong at CreateMatchWithInvites action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
            //CreateMatchWithInvitesCommand
            // var record = await _MatchManager.CreateMatchWithInvites(match);

            // if (record != null)
            //     return CreatedAtRoute("GetMatchById", new { id = record }, match);
            // return BadRequest("Save failed");
        }

        /// <summary>
        /// Manual Match Generation
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateMatchDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateMatch([FromBody] CreateMatchDTO match)
        {
            _Logger.LogInformation($"Matches: {HelperMethods.GetCallerMemberName()}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var record = await _MatchManager.CreateMatch(match);

            if (record != null)
                return CreatedAtRoute("GetMatchById", new { id = record }, match);
            return BadRequest("Save failed");
        }

        #endregion

        #region PUT/Update

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="match"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateMatchDetails(Guid id, [FromBody] UpdateMatchDetailsDTO match)
        {
            _Logger.LogInformation($"Matches: {HelperMethods.GetCallerMemberName()}");
            if (match == null)
            {
                _Logger.LogError("match object sent from client is null.");
                return BadRequest("Match object is null");
            }
            if (!ModelState.IsValid)
            {
                _Logger.LogError("Invalid match update object sent from client.");
                return BadRequest("Invalid model object");
            }

            //ok now lets try and update the details only
            try
            {
                var result = await Mediator.Send(new UpdateMatchDetailsCommand() { Match = match });
                if (result)
                    return NoContent();

                return BadRequest("Unable to update record");
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Something went wrong inside UpdateMatchDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        #endregion

        #region Delete

        // [HttpDelete]
        // public IActionResult Delete(Guid id)
        // {
        //     throw new NotImplementedException();
        // }

        #endregion
    }
}