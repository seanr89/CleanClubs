

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Club.API.Controllers;
using Clubs.Application.Profiles.Dto;
using Clubs.Application.Profiles.DTOs;
using Clubs.Application.Requests.Member.Commands;
using Clubs.Application.Requests.Member.Queries;
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
        [ProducesResponseType(typeof(IEnumerable<MemberDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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
        [ProducesResponseType(typeof(MemberDto), StatusCodes.Status200OK)]
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
        [HttpGet("{id}", Name="GetMembersByClubId")]
        [ProducesResponseType(typeof(IEnumerable<MemberDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetMembersByClubId(Guid id)
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
        [ProducesResponseType(typeof(CreateMemberDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]CreateMemberDTO member)
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

        [HttpPut("{id}")]  
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateMember(Guid id, [FromBody]MemberDto update)
        {
            _Logger.LogInformation($"method: {HelperMethods.GetCallerMemberName()}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var record = await Mediator.Send(new UpdateMemberCommand() {Member = update});
            if(record)
                return Ok("Member Updated!");

            return BadRequest("Update failed");
        }

        #endregion
    }
}