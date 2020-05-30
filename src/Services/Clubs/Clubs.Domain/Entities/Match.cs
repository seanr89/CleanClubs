

using System;

namespace Clubs.Domain.Entities
{
    public class Match
    {
        public Guid Id { get; set; }

        public Club Club { get; set; }

        public DateTime Date { get; set; }
    }
}