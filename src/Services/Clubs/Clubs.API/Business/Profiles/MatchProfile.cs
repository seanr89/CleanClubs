using AutoMapper;
using Clubs.API.Business.Matches.Commands;
using Clubs.API.Managers.Profiles.Dto;
using Clubs.Domain.Entities;

namespace Clubs.API.Managers.Profiles
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            // Default mapping when property names are same
            CreateMap<Match, MatchDto>();
            CreateMap<CreateMatchDTO, Match>();

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