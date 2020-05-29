using AutoMapper;

namespace Clubs.API.Managers.Profiles
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            // Default mapping when property names are same
            //CreateMap<Analysers.Domain.Entities.Analyser, AnalyserDto>();

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