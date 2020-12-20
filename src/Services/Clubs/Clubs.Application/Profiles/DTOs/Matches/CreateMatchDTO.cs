
using System;
using System.Collections.Generic;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;

namespace Clubs.Application.Profiles.DTO
{
    /// <summary>
    /// Match Create Model when teams have not been created
    /// N.B. NO INVITES!
    /// </summary>
    public class CreateMatchDTO
    {
        public Guid ClubId { get; set; }
        public DateTime Date { get; set; }
        public MatchStatus Status { get; set; } = MatchStatus.Created;
        public List<CreateTeamDTO> Teams { get; set; } = new List<CreateTeamDTO>();
        public string Location { get; set; }
    }

    /// <summary>
    /// New planned object to support match creation with invites!
    /// This supports invitation records to be sent!
    /// </summary>
    public class CreateInviteMatchDTO
    {
        public Guid ClubId { get; set; }
        public DateTime Date { get; set; }
        public MatchStatus Status { get; set; } = MatchStatus.Created;
        public List<CreateMemberDTO> SelectedMembers { get; set; } = new List<CreateMemberDTO>();
        public bool SendInvites { get; set; } = false;
        public string Location { get; set; }
    }
}