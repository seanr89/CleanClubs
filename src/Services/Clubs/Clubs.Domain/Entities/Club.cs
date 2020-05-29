using System;
using System.Collections.Generic;
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

        public bool Active { get; set; } = true;

        public ICollection<Player> Players { get; set; }
    }
}