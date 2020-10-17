

using System;
using System.Collections.Generic;

namespace Clubs.Application.Profiles.DTO
{
    public class ClubUpdateDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        public bool Private { get; set; } = false;
    }
}