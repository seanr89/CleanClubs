using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Club.API.Controllers;
using Clubs.Application.Profiles.DTO;
using Clubs.Application.Requests.Club.Commands;
using Clubs.Application.Requests.Users.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utilities;

namespace Clubs.API.Controllers
{
    public class UserController : ApiController
    {
        private readonly ILogger<UserController> _Logger;
        public UserController(ILogger<UserController> logger)
        {
            _Logger = logger;
        }

        #region GET

        /// <summary>
        /// Query all Users
        /// </summary>
        /// <returns>Collection of all User records</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            _Logger.LogInformation($"User: {HelperMethods.GetCallerMemberName()}");
            var result = await Mediator.Send(new GetUsersQuery());

            if (result.Any())
                return Ok(result);

            return NotFound("No records found");

        }

        /// <summary>
        /// Query a single User by the stored User Id
        /// </summary>
        /// <param name="id">unique Guid for a user</param>
        /// <returns>A single user record</returns>
        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            _Logger.LogInformation($"User: {HelperMethods.GetCallerMemberName()}");
            var result = await Mediator.Send(new GetUserQuery() { Id = id });

            if (result != null)
                return Ok(result);

            return NotFound("No record found");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">unique Guid for a user</param>
        /// <returns>A single user record</returns>
        [HttpGet("{id}", Name = "GetUserByObjectId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetUserByObjectId(string id)
        {
            _Logger.LogInformation($"User: {HelperMethods.GetCallerMemberName()}");
            var result = await Mediator.Send(new GetUserByObjectQuery() { ObjectId = id });

            if (result != null)
                return Ok(result);

            return NotFound("No record found");
        }

        #endregion

        #region POST

        /// <summary>
        /// Handle the creation of a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> NewUser(CreateUserDTO user)
        {
            _Logger.LogInformation($"User: {HelperMethods.GetCallerMemberName()}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var record = await Mediator.Send(new CreateUserCommand() { User = user });
            if (record != null)
                return CreatedAtRoute("GetUserById", new { id = record }, user);

            return BadRequest("Save failed");
        }

        #endregion
    }
}