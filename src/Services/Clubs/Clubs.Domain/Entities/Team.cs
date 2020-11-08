

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Clubs.Domain.Common;
using Clubs.Domain.Enums;

namespace Clubs.Domain.Entities
{
    public class Team : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid MatchId { get; set; }
        public Match Match { get; set; }
        /// <summary>
        /// Defines if this is the first or second team for easier defining!
        /// </summary>
        /// <value></value>
        public TeamNumber Number { get; set; }
        /// <summary>
        /// The players that have been assigned to the team
        /// </summary>
        /// <value></value>
        public ICollection<Player> Players { get; set; }
        /// <summary>
        /// The number of goals scored by this team
        /// </summary>
        /// <value></value>
        public int Score { get; set; }  = 0;
    }
}