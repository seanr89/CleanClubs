using AutoMapper;
using Clubs.API.Business.Member.Commands;
using Clubs.API.Managers.Profiles.Dto;
using Clubs.Domain.Entities;

namespace Clubs.API.Managers.Profiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            // Default mapping when property names are same
            CreateMap<Member, MemberDto>();
            CreateMap<CreateMemberDTO, Member>();
        }
    }
}