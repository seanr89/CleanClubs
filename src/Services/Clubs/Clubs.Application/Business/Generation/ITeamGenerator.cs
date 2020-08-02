

using System.Threading.Tasks;

namespace Clubs.Application.Business
{
    public interface ITeamGenerator
    {
        Task Generate(GenerationInfo info);
    }
}