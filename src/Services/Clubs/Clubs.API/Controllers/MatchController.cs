

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Club.API.Controllers;
using Clubs.API.Club.Queries;
using Clubs.API.Managers.Profiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Clubs.API.Controllers
{
    public class MatchController : ApiController
    {
        private readonly ILogger<MatchController> _Logger;
        public MatchController(ILogger<MatchController> logger)
        {
            _Logger = logger;
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
            throw new NotImplementedException();
        }

        [HttpGet("{id}", Name="GetByClubId")]
        public async Task<IActionResult> GetByClubId(Guid id)
        {
            throw new NotImplementedException();
        }

        #region POST

        #endregion


        #region PUT/Update

        #endregion

        #region Delete

        #endregion
    }
}