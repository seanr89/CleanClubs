
using System;

namespace Clubs.Messages.Contracts
{
    public class InvitationCreated
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public DateTime Date { get; set; }
    }
}