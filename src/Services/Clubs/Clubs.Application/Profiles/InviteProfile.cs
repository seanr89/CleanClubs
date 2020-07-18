using AutoMapper;
using Clubs.Application.Profiles.Dto;
using Clubs.Domain.Entities;

namespace Clubs.Application.Profiles
{
    public class InviteProfile : Profile
    {
        public InviteProfile()
        {
            // Default mapping when property names are same
            CreateMap<MemberDto, Invite>()
                .ForMember(dest =>
                dest.MemberId, opt => opt.MapFrom(src => src.Id));

            CreateMap<InviteDto, Invite>();
        }
    }
}