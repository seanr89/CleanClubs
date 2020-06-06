using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Clubs.Domain.Common;

namespace Clubs.Domain.Entities
{    
    public class Club : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; } = true;
        
        public string Creator { get; set; }

        public ICollection<Member> Members { get; set; }

        /// <summary>
        /// Record of matches played by a club
        /// </summary>
        /// <value></value>
        public ICollection<Match> Matches { get; set; }
    }
}