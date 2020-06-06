using AutoMapper;
using Clubs.API.ViewModels;

namespace Clubs.API.Managers.Profiles
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            // Default mapping when property names are same
            CreateMap<Clubs.Domain.Entities.Club, ClubDto>();
            CreateMap<CreateClubViewModel, Clubs.Domain.Entities.Club>();

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