

using System;
using System.Collections.Generic;

namespace Clubs.Application.Profiles.DTO
{
    public class ClubDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        public bool Private { get; set; }
        public string Creator { get; set; }
        public List<MemberDTO> Members { get; set; } = new List<MemberDTO>();
        
        //TODO: matches to be included!
    }
}