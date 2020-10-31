using AutoMapper;
using Clubs.Application.Profiles.DTO;
using Clubs.Domain.Entities;

namespace Clubs.Application.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            // Default mapping when property names are same
            CreateMap<Player, PlayerDTO>();
            CreateMap<PlayerDTO, Player>();
            CreateMap<CreatePlayerDTO, Player>();
        }
    }
}