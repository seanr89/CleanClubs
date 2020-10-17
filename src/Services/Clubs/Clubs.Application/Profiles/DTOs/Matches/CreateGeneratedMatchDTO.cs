
using System;
using System.Collections.Generic;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;

namespace Clubs.Application.Profiles.DTO
{
    /// <summary>
    /// Custom model to support Match creation when teams are already provided/generated
    /// </summary>
    public class CreateGeneratedMatchDTO
    {
        public Guid ClubId { get; set; }
        public DateTime Date { get; set; }
        public MatchStatus Status { get; set; } = MatchStatus.Created;
        public List<CreateTeamDTO> Teams { get; set; } = new List<CreateTeamDTO>();
        public string Location { get; set; }
    }
}