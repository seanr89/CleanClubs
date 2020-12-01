using System;
using Clubs.Domain.Common;

namespace Clubs.Domain.Entities
{
    public class User : AuditableEntity
    {
        public Guid Id { get; set; }
        /// <summary>
        /// External reference id from the authentication provider!
        /// </summary>
        /// <value></value>
        public string ObjectId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; private set; }
        public bool Active { get; private set; } = true;
        public DateTime LastLogin { get; set; } = DateTime.Now;

        /// <summary>
        /// private, parameterless constructor used by EF Core
        /// </summary>
        private User()
        {

        }

        public User(string objectId, string email, string displayName, bool active, DateTime lastLogin)
        {
            ObjectId = objectId;
            Email = email;
            DisplayName = displayName;
            Active = active;
            LastLogin = lastLogin;
        }

        #region Setter Methods

        public void Activate() => Active = true;
        public void DeActivate() => Active = false;

        #endregion
    }
}