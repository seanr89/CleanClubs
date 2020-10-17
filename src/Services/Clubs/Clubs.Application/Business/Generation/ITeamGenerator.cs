

using System.Threading.Tasks;
using Clubs.Application.Profiles.DTO;

namespace Clubs.Application.Business
{
    public interface ITeamGenerator
    {
        Task<MatchDTO> Generate(MatchDTO match);
    }
}