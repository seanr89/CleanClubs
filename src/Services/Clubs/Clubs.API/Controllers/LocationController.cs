using System.Collections.Generic;
using System.Threading.Tasks;
using Club.API.Controllers;
using Clubs.Application.Requests.Locations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Utilities;
using Clubs.Application.Profiles.DTO;
using System;

namespace Clubs.API.Controllers
{
    public class LocationController: ApiController
    {
        private readonly ILogger<LocationController> _Logger;
        public LocationController(ILogger<LocationController> logger)
        {
            _Logger = logger;
        }

        #region GET

        /// <summary>
        /// Query all locations
        /// </summary>
        /// <returns>Collection of location records</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LocationListDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            _Logger.LogInformation($"Club: {HelperMethods.GetCallerMemberName()}");
            var result = await Mediator.Send(new GetLocationsQuery());

            if (result.Any())
                return Ok(result);

            return NoContent();
        }

        /// <summary>
        /// Query a single Location by its Unique ID
        /// </summary>
        /// <param name="id">unique Guid for a Location</param>
        /// <returns>A single Location record</returns>
        [HttpGet("{id}", Name = "GetLocationById")]
        [ProducesResponseType(typeof(LocationDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLocationById(Guid id)
        {
            _Logger.LogInformation($"Club: {HelperMethods.GetCallerMemberName()}");
            var result = await Mediator.Send(new GetLocationQuery() { Id = id });

            if (result != null)
                return Ok(result);

            return NotFound();
        }

        #endregion
    }
}