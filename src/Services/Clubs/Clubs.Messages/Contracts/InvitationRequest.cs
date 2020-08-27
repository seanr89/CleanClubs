
using System;

namespace Clubs.Messages.Contracts
{
    public class InvitationRequest
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }
    }
}