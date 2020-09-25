using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Club.API.Controllers;
using Clubs.Application;
using Clubs.Application.Business;
using Clubs.Application.DTOs;
using Clubs.Application.Profiles.Dto;
using Clubs.Application.Requests.Matches.Queries;
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
        [ProducesResponseType(typeof(IEnumerable<MatchListDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            _Logger.LogInformation($"Matches: {HelperMethods.GetCallerMemberName()}");
            var result = await Mediator.Send(new GetMatchesQuery());
            if (result.Any())
                return Ok(result);

            return StatusCode(204);
        }

        [HttpGet("{id}", Name = "GetMatchById")]
        [ProducesResponseType(typeof(MatchDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetMatchById(Guid id)
        {
            _Logger.LogInformation($"Matches: {HelperMethods.GetCallerMemberName()}");
            var result = await Mediator.Send(new GetMatchQuery() { MatchId = id });

            if (result != null)
                return Ok(result);

            return StatusCode(204, "No Record Found");
        }

        // [HttpGet("{id}", Name = "GetMatchesByClubId")]
        // [ProducesResponseType(typeof(IEnumerable<MatchDto>), StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status204NoContent)]
        // public async Task<IActionResult> GetMatchesByClubId(Guid id)
        // {
        //     _Logger.LogInformation($"Matches: {HelperMethods.GetCallerMemberName()}");
        //     var result = await Mediator.Send(new GetClubMatchesQuery() { ClubId = id });

        //     if (result.Any())
        //         return Ok(result);

        //     return StatusCode(204, "No Records Found");
        // }

        #region POST

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
            var record = await _MatchManager.CreateMatchWithInvites(match);

            if (record != null)
                return CreatedAtRoute("GetMatchById", new { id = record }, match);
            return BadRequest("Save failed");
        }

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

        // [HttpPost]
        // public async Task<IActionResult> CreateMatchWithTeams()
        // {
        //     throw new NotImplementedException();
        // }

        #endregion

        #region PUT/Update

        // [HttpPut]
        // public IActionResult Update(Guid id)
        // {
        //     throw new NotImplementedException();
        // }

        //[HttpPut]
        // public IActionResult UpdateMatchCancelled()
        // {

        // }

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