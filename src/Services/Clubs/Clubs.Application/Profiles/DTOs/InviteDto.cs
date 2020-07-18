using System;
using System.Collections.Generic;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;

//https://exceptionnotfound.net/entity-framework-and-wcf-mapping-entities-to-dtos-with-automapper/
namespace Clubs.Application.Profiles
{
    public class InviteDto
    {
        public Guid Id { get; set; }
        public bool Accepted { get; set; }
    }
}