using AutoMapper;
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

            // Mapping when property names are different
            //CreateMap<User, UserViewModel>()
            //    .ForMember(dest =>
            //    dest.FName,
            //    opt => opt.MapFrom(src => src.FirstName))
            //    .ForMember(dest =>
            //    dest.LName,
            //    opt => opt.MapFrom(src => src.LastName));
        }
    }
}