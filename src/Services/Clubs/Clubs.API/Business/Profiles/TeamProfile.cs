using AutoMapper;
using Clubs.API.Managers.Profiles.Dto;
using Clubs.Domain.Entities;

namespace Clubs.API.Managers.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            // Default mapping when property names are same
            CreateMap<Team, TeamDto>();
        }
    }
}