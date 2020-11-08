
using System;

namespace Clubs.Application.Profiles.DTO
{
    public class LocationListDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SiteURL { get; private set; } 
        public bool Active { get; set; }
    }
}