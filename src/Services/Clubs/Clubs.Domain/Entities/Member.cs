using System;
using System.ComponentModel.DataAnnotations;
using Clubs.Domain.Common;

namespace Clubs.Domain.Entities
{
    public class Member : AuditableEntity
    {
        [Key]
        public Guid Id { get; private set; }
        [Required]
        public string FirstName { get; private set; }
        [Required]
        public string LastName { get; private set; }
        [Required]
        public string Email { get; private set; }
        public bool Active { get; private set; } = true;
        public double Rating { get; private set; } = 50.0;
        public Club Club { get; set; }
        public Guid ClubId { get; set; }

        /// <summary>
        /// TODO: private, parameterless constructor used by EF Core
        /// </summary>
        private Member()
        {
            
        }

        public Member(string firstName, string lastName, string email, double rating)
        {
            
        }

        #region Public_Accessors

        public void Activate() => Active = true;
        public void DeActivate() => Active = false;

        #endregion
    }
}