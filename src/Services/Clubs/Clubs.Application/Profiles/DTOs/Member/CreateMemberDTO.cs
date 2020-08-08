
using System;

namespace Clubs.Application.Profiles.DTOs
{
    public class CreateMemberDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; } = true;
        public double Rating { get; set; }
        public Guid ClubId { get; set; }
    }
}