

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Club.API.Controllers;
using Clubs.API.Business.Managers;
using Clubs.API.Club.Commands;
using Clubs.API.Club.Queries;
using Clubs.API.Managers.Profiles;
using Clubs.API.ViewModels;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetMatchesQuery());
            if (result.Any())
                return Ok(result);

            return StatusCode(204, "No Matches Found");
        }

        [HttpGet("{id}", Name="GetMatchById")]
        public async Task<IActionResult> GetMatchById(Guid id)
        {
            _Logger.LogInformation($"method: {HelperMethods.GetCallerMemberName()}");
            var result = await Mediator.Send(new GetMatchQuery() {MatchId = id});

            if (result != null)
                return Ok(result);

            return StatusCode(204, "No Record Found");

        }

        [HttpGet("{id}", Name="GetMatchesByClubId")]
        public async Task<IActionResult> GetMatchesByClubId(Guid id)
        {
            _Logger.LogInformation($"method: {HelperMethods.GetCallerMemberName()}");
            var result = await Mediator.Send(new GetClubMatchesQuery() {ClubId = id});

            if (result.Any())
                return Ok(result);

            return StatusCode(204, "No Records Found");
        }

        #region POST

        [HttpPost]
        [ProducesResponseType(typeof(CreateMatchViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]CreateMatchViewModel match)
        {
            _Logger.LogInformation($"method: {HelperMethods.GetCallerMemberName()}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var record = await _MatchManager.CreateMatch(match);
            // var record = await Mediator.Send(new CreateMatchCommand() {Match = match});
            if(record != null)
                return CreatedAtRoute("GetMatchById", new{ id = record}, match);

            return BadRequest("Save failed");
        }

        #endregion


        #region PUT/Update

        #endregion

        #region Delete

        #endregion
    }
}