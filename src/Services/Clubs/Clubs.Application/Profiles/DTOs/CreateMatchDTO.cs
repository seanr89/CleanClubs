
using System;
using System.Collections.Generic;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;

namespace Clubs.Application.DTOs
{
    public class CreateMatchDTO
    {
        public Guid ClubId { get; set; }
        public DateTime Date { get; set; }
        public MatchStatus Status { get; set; } = MatchStatus.Created;
        public bool InviteActiveMembers { get; set; } = true;
        public bool SendInvites { get; set; } = false;
    }
}