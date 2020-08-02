using System;
using System.Collections.Generic;
using Clubs.Application.Profiles.Dto;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;

//https://exceptionnotfound.net/entity-framework-and-wcf-mapping-entities-to-dtos-with-automapper/
namespace Clubs.Application.Profiles
{
    public class InviteDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Flag to say if accepted or not
        /// </summary>
        /// <value></value>
        public bool Accepted { get; set; }
        //TODO: add the email/contact info probs!
        public MemberDto Member { get; set; }
    }
}