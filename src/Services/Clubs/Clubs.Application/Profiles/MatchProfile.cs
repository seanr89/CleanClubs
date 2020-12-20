using AutoMapper;
using Clubs.Application.Profiles.DTO;
using Clubs.Domain.Entities;

namespace Clubs.Application.Profiles
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            // Default mapping when property names are same
            CreateMap<Match, MatchDTO>();
            CreateMap<MatchDTO, Match>();
            CreateMap<Match, MatchListDTO>();
            CreateMap<CreateMatchDTO, Match>();
            CreateMap<CreateInviteMatchDTO, Match>();
        }
    }
}