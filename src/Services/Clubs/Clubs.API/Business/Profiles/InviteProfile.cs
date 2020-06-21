using AutoMapper;
using Clubs.API.Managers.Profiles.Dto;
using Clubs.API.ViewModels;
using Clubs.Domain.Entities;

namespace Clubs.API.Managers.Profiles
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