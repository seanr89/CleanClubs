

using Clubs.Application.Profiles.DTO;
using Clubs.Domain.Enums;

namespace Clubs.Application.Business
{
    public class GenerationInfo
    {
        public MatchDTO Match { get; set; }
        public GeneratorType GeneratorOption { get; set; }
    }
}