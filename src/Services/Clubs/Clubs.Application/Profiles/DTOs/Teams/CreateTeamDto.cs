using System;
using System.Collections.Generic;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;

//https://exceptionnotfound.net/entity-framework-and-wcf-mapping-entities-to-dtos-with-automapper/
namespace Clubs.Application.Profiles.Dto
{
    public class CreateTeamDto
    {
        //public Guid Id { get; set; }
        /// <summary>
        /// Defines if this is the first or second team
        /// </summary>
        /// <value></value>
        public TeamNumber Number { get; set; }
        /// <summary>
        /// The players that have been assigned to the team
        /// </summary>
        /// <value></value>
        public List<CreatePlayerDto> Players { get; set; } = new List<CreatePlayerDto>();

        public Guid MatchId { get; set; }
    }
}