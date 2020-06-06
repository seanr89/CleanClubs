using System;

//https://exceptionnotfound.net/entity-framework-and-wcf-mapping-entities-to-dtos-with-automapper/
namespace Clubs.API.Managers.Profiles
{
    public class PlayerDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool Active { get; set; }

        //public ClubDto Club { get; set; }
        //public string ClubName { get; set; } = "Unknown";
    }
}