using AutoMapper;
using Clubs.Application.Profiles.Dto;
using Clubs.Domain.Entities;

namespace Clubs.Application.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            // Default mapping when property names are same
            CreateMap<Player, PlayerDto>();

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