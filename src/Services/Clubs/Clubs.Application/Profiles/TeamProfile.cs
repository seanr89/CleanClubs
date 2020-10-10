using AutoMapper;
using Clubs.Application.Profiles.Dto;
using Clubs.Domain.Entities;

namespace Clubs.Application.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            // Default mapping when property names are same
            CreateMap<Team, TeamDto>();
            CreateMap<TeamDto, Team>();
            CreateMap<CreateTeamDto, Team>();
        }
    }
}