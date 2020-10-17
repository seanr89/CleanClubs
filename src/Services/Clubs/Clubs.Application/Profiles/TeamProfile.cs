using AutoMapper;
using Clubs.Application.Profiles.DTO;
using Clubs.Domain.Entities;

namespace Clubs.Application.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            // Default mapping when property names are same
            CreateMap<Team, TeamDTO>();
            CreateMap<TeamDTO, Team>();
            CreateMap<CreateTeamDTO, Team>();
        }
    }
}