using System;
using System.Threading.Tasks;

namespace Clubs.Application.Services.Interfaces
{
    public interface IMatchCreator
    {
      Task<Guid?> Create(object match);
    }
}