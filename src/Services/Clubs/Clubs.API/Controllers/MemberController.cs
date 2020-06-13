

using System;
using System.Collections.Generic;
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

namespace Clubs.API.Controllers
{
    public class MemberController : ApiController
    {
        private readonly ILogger<MemberController> _Logger;
        public MemberController(ILogger<MemberController> logger)
        {
            _Logger = logger;
        }

        #region GET

        [HttpGet]
        public async Task<IEnumerable<MemberDto>> Get()
        {
            return await Mediator.Send(new GetAllMembersQuery());
        }

        /// <summary>
        /// Query A single member
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name="GetMemberById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetMemberById(Guid id)
        {
            _Logger.LogInformation($"method: {HelperMethods.GetCallerMemberName()}");

            var result = await Mediator.Send(new GetMemberQuery(){ Id = id});

            if (result != null)
                return Ok(result);

            return StatusCode(204, "No Record Found");
        }

        /// <summary>
        /// Query All Members of a club
        /// </summary>
        /// <param name="id">Club ID</param>
        /// <returns></returns>
        [HttpGet("{id}", Name="GetByClubId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByClubId(Guid id)
        {
            _Logger.LogInformation($"method: {HelperMethods.GetCallerMemberName()}");

            var result = await Mediator.Send(new GetClubMembersQuery() {ClubId = id});

            if (result != null)
                return Ok(result);

            return StatusCode(204, "No Record Found");
        }

        #endregion

        #region POST

        [HttpPost]
        [ProducesResponseType(typeof(CreateMemberViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]CreateMemberViewModel member)
        {
            _Logger.LogInformation($"method: {HelperMethods.GetCallerMemberName()}");
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var record = await Mediator.Send(new CreateMemberCommand() {Member = member});
            if(record != null)
                return CreatedAtRoute("GetMemberById", new{ id = record}, member);

            return BadRequest("Save failed");
        }

        #endregion

        #region PUT/UPDATE

        #endregion
    }
}