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
        [Required]
        /// <summary>
        /// Active status can probably be removed from this as now part of member!
        /// </summary>
        /// <value></value>
        public bool Active { get; set; } = true;
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