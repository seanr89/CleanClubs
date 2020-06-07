

using System;
using System.Collections.Generic;

namespace Clubs.API.Managers.Profiles
{
    public class ClubDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        public bool Private { get; set; }
        public string Creator { get; set; }
        public List<MemberDto> Members { get; set; } = new List<MemberDto>();
    }
}