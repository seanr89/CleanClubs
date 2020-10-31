using AutoMapper;
using Clubs.Application.Profiles.DTO;

namespace Clubs.Application.Profiles
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            // Default mapping when property names are same
            CreateMap<Clubs.Domain.Entities.Club, ClubDTO>();
            CreateMap<Clubs.Domain.Entities.Club, ClubListDTO>();
            CreateMap<CreateClubDTO, Clubs.Domain.Entities.Club>();
        }
    }
}