using System;

namespace Clubs.Application.Profiles.DTO
{
    public class PlayerListDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}