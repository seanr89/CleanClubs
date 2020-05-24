using System.Collections.Generic;

namespace Clubs.Domain{
    
    public class Club
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}