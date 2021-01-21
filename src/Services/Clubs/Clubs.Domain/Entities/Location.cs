using System;
using System.ComponentModel.DataAnnotations;
using Clubs.Domain.Common;
using NetTopologySuite.Geometries;

namespace Clubs.Domain.Entities
{
    public class Location : AuditableEntity
    {
        [Key]
        public Guid Id { get; private set; }
        
        [Required]
        [StringLength(250)]
        public string Name { get; private set; }
        [Required]  
        public string AddressOne { get; private set; }
        public string AddressTwo { get; private set; }
        [Required]  
        public string PostCode { get; private set; }
        public bool Active { get; set; } = true;
        public Point GeoLocation { get; private set; }
        public string SiteURL { get; private set; } 

        /// <summary>
        /// private, parameterless constructor used by EF Core
        /// </summary>
        private Location(){}

        /// <summary>
        /// public, parameter specific constructor to initialise objects
        /// </summary>
        /// <param name="name"></param>
        /// <param name="addressOne"></param>
        /// <param name="addressTwo"></param>
        /// <param name="postcode"></param>
        /// <param name="active"></param>
        /// <param name="url"></param>
        public Location(string name, string addressOne, string addressTwo, string postcode, bool active, string url)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
            AddressOne = addressOne;
            AddressTwo = addressTwo;
            PostCode = postcode;
            Active = active;
            SiteURL = url;
        }


        #region Setter Methods

        /// <summary>
        /// Public Setter for updating the name
        /// </summary>
        /// <param name="name">The new location name</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the name is null or whitespace</exception>
        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            Name = name;
        }

        public void Activate() => Active = true;
        public void DeActivate() => Active = false;

        #endregion
    }
}