
using Microsoft.Extensions.Logging;

namespace Emails.App
{
    public class InviteEmailer
    {
        private readonly ILogger<InviteEmailer> _Logger;
        public InviteEmailer(ILogger<InviteEmailer> logger)
        {
            _Logger = logger;
        }
    }
}