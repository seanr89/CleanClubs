using System;
using System.Collections.Generic;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;

//https://exceptionnotfound.net/entity-framework-and-wcf-mapping-entities-to-dtos-with-automapper/
namespace Clubs.Application.Profiles.Dto
{
    public class MatchDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public MatchStatus Status { get; set; }
        public List<InviteDto> Invites { get; set; }
        public List<TeamDto> Teams { get; set; } = new List<TeamDto>();
        public string Location { get; set; }
    }
}