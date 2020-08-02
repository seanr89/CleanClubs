

using System.Collections.Generic;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;

namespace Generators
{
    public struct GenerationInfo
    {
        public Match Match { get; set; }
        public GeneratorType GeneratorOption { get; set; }
    }
}