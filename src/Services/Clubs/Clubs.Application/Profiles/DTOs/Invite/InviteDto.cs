using System;
using System.Collections.Generic;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;

//https://exceptionnotfound.net/entity-framework-and-wcf-mapping-entities-to-dtos-with-automapper/
namespace Clubs.Application.Profiles.DTO
{
    public class InviteDTO
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Flag to say if invitation has been accepted or not
        /// </summary>
        /// <value></value>
        public bool Accepted { get; set; }
        //TODO: add the email/contact info probs!
        public MemberDTO Member { get; set; }
    }
}