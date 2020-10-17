using AutoMapper;
using Clubs.Application.Profiles.DTO;
using Clubs.Domain.Entities;

namespace Clubs.Application.Profiles
{
    public class InviteProfile : Profile
    {
        public InviteProfile()
        {
            // Default mapping when property names are same
            CreateMap<MemberDTO, Invite>()
                .ForMember(dest =>
                dest.MemberId, opt => opt.MapFrom(src => src.Id));

            CreateMap<InviteDTO, Invite>();
            CreateMap<Invite, InviteDTO>();
        }
    }
}