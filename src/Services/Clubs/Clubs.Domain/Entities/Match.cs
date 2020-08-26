

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
        [Required]
        public Guid ClubId { get; set; }
        public Club Club { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public MatchStatus Status { get; set; }
        public List<Team> Teams { get; set; } = new List<Team>();
        public ICollection<Invite> Invites { get; set; } = new List<Invite>();
        public bool InvitesSent { get; set; } = false;
        public GeneratorType Generator { get; set; } = GeneratorType.None;
        public string Location { get; set; } = "Unknown";

    }
}