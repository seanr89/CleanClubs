using System;
using System.Threading.Tasks;
using Clubs.Application.Profiles.DTO;

namespace Clubs.Application.Services.Interfaces
{
    public interface IMatchCreator
    {
        Task<Guid?> Create(object match);
    }
}