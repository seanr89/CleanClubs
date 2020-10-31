using System;
using System.ComponentModel.DataAnnotations;
using Clubs.Domain.Common;

namespace Clubs.Domain.Entities
{
    public class Player : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// The rating of the player. taken from the member field so could be removed
        /// default = 50
        /// </summary>
        /// <value></value>
        public double Rating { get; set; } = 50.0;
        /// <summary>
        /// Member - perhaps can be nullable to support temporary players in a club!
        /// </summary>
        /// <value></value>
        public Guid MemberId { get; set; }
        public Member Member { get; set; }
        /// <summary>
        /// Links back to support navigation to the respective Team information
        /// </summary>
        /// <value></value>
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}