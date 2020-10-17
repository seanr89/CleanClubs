using System;
using System.Collections.Generic;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;

//https://exceptionnotfound.net/entity-framework-and-wcf-mapping-entities-to-dtos-with-automapper/
namespace Clubs.Application.Profiles.DTO
{
    public class CreatePlayerDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        //public bool Active { get; set; }
        public double Rating { get; set; }
        public Guid MemberId { get; set; }
    }
}