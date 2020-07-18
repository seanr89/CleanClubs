using AutoMapper;

namespace Clubs.Application.Profiles
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            // Default mapping when property names are same
            CreateMap<Clubs.Domain.Entities.Club, ClubDto>();
            CreateMap<Clubs.Domain.Entities.Club, ClubListDto>();
            CreateMap<CreateClubDTO, Clubs.Domain.Entities.Club>();
            CreateMap<ClubUpdateDto, Clubs.Domain.Entities.Club>();
        }
    }
}