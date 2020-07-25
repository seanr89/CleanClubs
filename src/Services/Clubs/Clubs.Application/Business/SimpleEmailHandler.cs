

using System.Collections.Generic;
using System.Threading.Tasks;
using Clubs.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Clubs.Application.Business
{
    public class SimpleEmailHandler
    {
        private readonly ILogger<SimpleEmailHandler> _Logger;
        public SimpleEmailHandler(ILogger<SimpleEmailHandler> logger)
        {
            _Logger = logger;
        }

        public async Task generateAndSendInviteEmails(IEnumerable<Invite> invites)
        {
            foreach (var invite in invites)
            {

            }
        }

        private string generateEmailContent(Invite inv)
        {
            string message = "";

            return message;
        }
    }
}