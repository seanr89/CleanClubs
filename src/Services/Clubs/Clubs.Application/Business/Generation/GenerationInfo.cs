

using Clubs.Application.Profiles.Dto;
using Clubs.Domain.Enums;

namespace Clubs.Application.Business
{
    public class GenerationInfo
    {
        public MatchDto Match { get; set; }
        public GeneratorType GeneratorOption { get; set; }
    }
}