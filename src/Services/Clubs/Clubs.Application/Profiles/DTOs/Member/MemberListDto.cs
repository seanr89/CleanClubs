using System;

namespace Clubs.Application.Profiles.DTO
{
    /// <summary>
    /// Custom DTO for use when creating List/Collection of member records
    /// </summary>
    public class MemberListDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool Active { get; set; } = true;
    }
}