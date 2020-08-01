using System;
using System.ComponentModel.DataAnnotations;
using Clubs.Domain.Common;

namespace Clubs.Domain.Entities
{
    public class Member : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public bool Active { get; set; } = true;
        public double Rating { get; set; } = 50.0;
        public Club Club { get; set; }
        public Guid ClubId { get; set; }
    }
}