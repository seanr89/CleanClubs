using System;

namespace Emails.Domain
{
    public class Invitation
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}