using System;
using System.Collections.Generic;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;

//https://exceptionnotfound.net/entity-framework-and-wcf-mapping-entities-to-dtos-with-automapper/
namespace Clubs.API.Managers.Profiles
{
    public class MatchDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public MatchStatus Status { get; set; }
        public List<Invite> Invites { get; set; }
    }
}