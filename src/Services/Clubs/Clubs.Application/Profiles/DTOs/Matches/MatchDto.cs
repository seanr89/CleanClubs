using System;
using System.Collections.Generic;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;

//https://exceptionnotfound.net/entity-framework-and-wcf-mapping-entities-to-dtos-with-automapper/
namespace Clubs.Application.Profiles.DTO
{
    public class MatchDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public MatchStatus Status { get; set; }
        public List<InviteDTO> Invites { get; set; }
        public List<TeamDTO> Teams { get; set; } = new List<TeamDTO>();
        public string Location { get; set; }
        public Guid ClubId { get; set; }
    }
}