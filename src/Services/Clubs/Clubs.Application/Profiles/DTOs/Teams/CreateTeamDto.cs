using System;
using System.Collections.Generic;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;

//https://exceptionnotfound.net/entity-framework-and-wcf-mapping-entities-to-dtos-with-automapper/
namespace Clubs.Application.Profiles.DTO
{
    public class CreateTeamDTO
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
        public List<CreatePlayerDTO> Players { get; set; } = new List<CreatePlayerDTO>();
        /// <summary>
        /// MatchId appended to ensure it can be saved properly!
        /// </summary>
        /// <value></value>
        public Guid MatchId { get; set; }
    }
}