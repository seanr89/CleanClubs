

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Clubs.Domain.Common;
using Clubs.Domain.Enums;

namespace Clubs.Domain.Entities
{
    public class Match : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Club Club { get; set; }
        public DateTime Date { get; set; }
        public MatchStatus Status { get; set; }
        public ICollection<Team> Teams { get; set; }
        public ICollection<Invite> Invites { get; set; }
    }
}