
using System;
using System.Collections.Generic;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;

namespace Clubs.Application.Profiles.DTO
{
    /// <summary>
    /// Match Create Model when teams have not been created!
    /// </summary>
    public class CreateMatchDTO
    {
        public Guid ClubId { get; set; }
        public DateTime Date { get; set; }
        public MatchStatus Status { get; set; } = MatchStatus.Created;
        public bool InviteActiveMembers { get; set; } = true;
        public List<CreateMemberDTO> SelectedMembers { get; set; } = new List<CreateMemberDTO>();
        public List<CreateTeamDTO> Teams { get; set; } = new List<CreateTeamDTO>();
        public bool SendInvites { get; set; } = false;
        public string Location { get; set; }
    }
}