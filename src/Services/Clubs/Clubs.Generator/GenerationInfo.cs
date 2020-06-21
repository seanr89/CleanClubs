

using System.Collections.Generic;
using Clubs.Domain.Entities;
using Clubs.Domain.Enums;

namespace Clubs.Generator
{
    public struct GenerationInfo
    {
        public List<Invite> Invites { get; set; }
        public GeneratorType GeneratorOption { get; set; }
    }
}