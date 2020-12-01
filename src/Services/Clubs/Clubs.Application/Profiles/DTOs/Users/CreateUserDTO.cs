using System;

namespace Clubs.Application.Profiles.DTO
{
    public class CreateUserDTO
    {
        public string ObjectId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; private set; }
    }
}