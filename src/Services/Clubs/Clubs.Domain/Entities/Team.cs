

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Clubs.Domain.Enums;

namespace Clubs.Domain.Entities
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid MatchId { get; set; }
        public Match Match { get; set; }

        /// <summary>
        /// Defines if this is the first or second team
        /// </summary>
        /// <value></value>
        public TeamNumber Number { get; set; }
        /// <summary>
        /// The players that have been assigned to the team
        /// </summary>
        /// <value></value>
        public ICollection<Player> Players { get; set; }
    }
}