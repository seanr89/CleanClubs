

using System.Threading.Tasks;
using Clubs.Application.Profiles.Dto;

namespace Clubs.Application.Business
{
    public interface ITeamGenerator
    {
        Task<MatchDto> Generate(GenerationInfo info);
    }
}