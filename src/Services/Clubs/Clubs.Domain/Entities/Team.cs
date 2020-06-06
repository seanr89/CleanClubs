

using System;
using System.Collections.Generic;
using Clubs.Domain.Enums;

namespace Clubs.Domain.Entities
{
    public class Team
    {
        public Guid Id { get; set; }
        
        public Match Match { get; set; }

        public TeamNumber Number { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}