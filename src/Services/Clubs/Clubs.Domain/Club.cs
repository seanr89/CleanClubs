using System;
using System.Collections.Generic;

namespace Clubs.Domain{
    
    public class Club
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}