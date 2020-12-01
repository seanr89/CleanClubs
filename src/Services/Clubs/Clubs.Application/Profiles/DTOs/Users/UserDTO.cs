using System;

namespace Clubs.Application.Profiles.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        /// <summary>
        /// External reference id from the authentication provider!
        /// </summary>
        /// <value></value>
        public string ObjectId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }
    }
}