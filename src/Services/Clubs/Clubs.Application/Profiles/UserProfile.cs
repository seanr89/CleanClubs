using AutoMapper;
using Clubs.Application.Profiles.DTO;
using Clubs.Domain.Entities;

namespace Clubs.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Default mapping when property names are same
            CreateMap<User, UserDTO>();
            CreateMap<CreateUserDTO, User>();
        }
    }
}