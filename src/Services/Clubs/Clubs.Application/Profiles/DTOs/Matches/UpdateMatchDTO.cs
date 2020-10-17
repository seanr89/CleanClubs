
using System;
using System.Collections.Generic;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;

namespace Clubs.Application.Profiles.DTO
{
    public class UpdateMatchDTO
    {
        public Guid ClubId { get; set; }
        public DateTime Date { get; set; }
        public MatchStatus Status { get; set; } = MatchStatus.Created;
        public bool InviteActiveMembers { get; set; } = true;
        public List<MemberDTO> SelectedMembers { get; set; } = new List<MemberDTO>();
        public bool SendInvites { get; set; } = false;
        public string Location { get; set; }
    }
}