

using System;

namespace Clubs.API.Managers.Profiles
{
    public class ClubDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; } = true;
    }
}