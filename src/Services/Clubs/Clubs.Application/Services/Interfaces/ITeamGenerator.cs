using System.Threading.Tasks;
using Clubs.Application.Profiles.DTO;

namespace Clubs.Application.Services.Interfaces
{
    public interface ITeamGenerator
    {
        Task<MatchDTO> Generate(MatchDTO match);
    }
}