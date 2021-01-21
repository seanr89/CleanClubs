using System.Threading.Tasks;
using Clubs.Application.Profiles.DTO;
using Clubs.Application.Services.Interfaces;

namespace Clubs.Application.Services.Generators
{
    public class StatsTeamGenerator : ITeamGenerator
    {
        public Task<MatchDTO> Generate(MatchDTO match)
        {
            throw new System.NotImplementedException();
        }
    }
}