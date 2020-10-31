

using System;
using System.Collections.Generic;
namespace Clubs.Application.Profiles.DTO
{
    public class ClubListDTO
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; } = true;
        public bool Private { get; private set; }
        public string Creator { get; private set; }
    }
}