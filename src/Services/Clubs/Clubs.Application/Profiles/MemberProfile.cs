using AutoMapper;
using Clubs.Application.Profiles.Dto;
using Clubs.Application.Profiles.DTOs;
using Clubs.Domain.Entities;

namespace Clubs.Application.Profiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            // Default mapping when property names are same
            CreateMap<Member, MemberDto>();
            CreateMap<MemberDto, Member>();
            CreateMap<CreateMemberDTO, Member>();
        }
    }
}