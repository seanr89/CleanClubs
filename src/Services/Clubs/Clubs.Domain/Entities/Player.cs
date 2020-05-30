using System;
using System.ComponentModel.DataAnnotations;

namespace Clubs.Domain.Entities
{
    public class Player
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
        public Club Club { get; set; }
    }
}