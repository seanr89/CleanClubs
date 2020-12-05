using System;
using NetTopologySuite.Geometries;
namespace Clubs.Application.Profiles.DTO
{
    public class LocationDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SiteURL { get; private set; } 
        public string AddressOne { get; private set; }
        public string AddressTwo { get; private set; }
        public string PostCode { get; private set; }
        public bool Active { get; set; }
        //public Point GeoLocation { get; private set; }
    }
}