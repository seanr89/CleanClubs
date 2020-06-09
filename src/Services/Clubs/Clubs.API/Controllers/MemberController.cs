

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Club.API.Controllers;
using Clubs.API.Club.Queries;
using Clubs.API.Managers.Profiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utilities;

namespace Clubs.API.Controllers
{
    public class MemberController : ApiController
    {
        private readonly ILogger<MemberController> _Logger;
        public MemberController(ILogger<MemberController> logger)
        {
            _Logger = logger;
        }


        [HttpGet]
        public async Task<IEnumerable<MatchDto>> Get()
        {
            return await Mediator.Send(new GetMatchesQuery());
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
            // var result = await Mediator.Send(new GetClubQuery() {Id = id});

            // if (result != null)
            //     return Ok(result);

            return StatusCode(204, "No Record Found");
        }
    }
}