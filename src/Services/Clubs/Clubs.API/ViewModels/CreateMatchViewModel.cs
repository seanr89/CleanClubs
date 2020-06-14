
using System;
using System.Collections.Generic;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;

namespace Clubs.API.ViewModels
{
    public class CreateMatchViewModel
    {
        public Guid ClubId { get; set; }
        public DateTime Date { get; set; }
        public MatchStatus Status { get; set; } = MatchStatus.Created;
        public bool InviteActiveMembers { get; set; } = true;
        public bool SendInvites { get; set; } = false;
    }
}