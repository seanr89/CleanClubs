using System;

namespace Emails.Domain
{
    /// <summary>
    /// Custom emails app model for invitation details!
    /// </summary>
    public class Invitation
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public DateTime Date { get; private set; }
        //public string Location { get; set; }
    }
}