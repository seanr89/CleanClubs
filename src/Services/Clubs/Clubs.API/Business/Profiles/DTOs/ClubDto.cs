

using System;
using System.Collections.Generic;

namespace Clubs.API.Managers.Profiles
{
    public class ClubDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; } = true;

        public List<PlayerDto> Players { get; set; } = new List<PlayerDto>();
    }
}