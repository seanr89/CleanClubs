using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Utilities;

namespace Emails.Messages
{
    public class InvitationReceiever
    {
        private readonly IQueueClient _queueClient;
        private readonly ILogger<InvitationReceiever> _logger;

        public InvitationReceiever(IQueueClient queueClient, ILogger<InvitationReceiever> logger)
        {
            _queueClient = queueClient;
            _logger = logger;
        }


        public Task Receive()
        {
            return null;
        }
    }
}