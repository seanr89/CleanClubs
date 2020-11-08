using AutoMapper;
using Clubs.Application.Profiles.DTO;
using Clubs.Domain.Entities;

namespace Clubs.Application.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            // Default mapping when property names are same
            CreateMap<Location, LocationDTO>();
            CreateMap<Location, LocationListDTO>();
        }
    }
}