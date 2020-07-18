

using System;
using System.Collections.Generic;

namespace Clubs.Application.Profiles
{
    public class ClubListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        public bool Private { get; set; }
        public string Creator { get; set; }
    }
}