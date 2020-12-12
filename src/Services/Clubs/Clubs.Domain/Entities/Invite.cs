using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Clubs.Domain.Common;

namespace Clubs.Domain.Entities
{
    public class Invite : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid MemberId { get; set; }
        public Member Member { get; set; }
        public string Email { get; set; }
        public bool Accepted { get; set; } = false;
        public DateTime? Date { get; set; }
        [JsonIgnore]
        public Match Match { get; set; }
        public Guid MatchId { get; set; }

        /// <summary>
        /// parameterless, private constructor disabled
        /// </summary>
        private Invite()
        {

        }

        /// <summary>
        /// new parameter based constructor
        /// </summary>
        /// <param name="email"></param>
        /// <param name="memberId"></param>
        /// <param name="matchId"></param>
        public Invite(string email, Guid memberId, Guid matchId)
        {
            Email = email;
            MemberId = memberId;
            MatchId = matchId;
        }
    }
}