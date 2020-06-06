

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
        
        public Match Match { get; set; }

        public TeamNumber Number { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}