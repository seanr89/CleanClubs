using AutoMapper;
using Clubs.API.ViewModels;
using Clubs.Domain.Entities;

namespace Clubs.API.Managers.Profiles
{
    public class InviteProfile : Profile
    {
        public InviteProfile()
        {
            // Default mapping when property names are same
            CreateMap<Member, Invite>();
        }
    }
}