using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Utilities;
using Microsoft.Extensions.Hosting;
using System.Threading;
using Clubs.Domain.Entities;

namespace Emails.App
{
    public class InvitationReceieverService : BackgroundService
    {
        private readonly ISubscriptionClient _SubscriptionClient;
        private readonly ILogger<InvitationReceieverService> _Logger;
        private readonly EmailHandler _EmailHandler;

        public InvitationReceieverService(ISubscriptionClient subscriptionClient, ILogger<InvitationReceieverService> logger)
        {
            _SubscriptionClient = subscriptionClient;
            _Logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _SubscriptionClient.RegisterMessageHandler((message, token) =>
            {
                var invite = JsonConvert.DeserializeObject<Invite>(Encoding.UTF8.GetString(message.Body));

                _EmailHandler.GenerateAndSendInviteEmail(invite);

                //Stops potential duplicate processing
                return _SubscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
            },
            new MessageHandlerOptions(args => Task.CompletedTask)
            {
                //exception handling
                AutoComplete = false,
                MaxConcurrentCalls = 1
            });
            return Task.CompletedTask;
        }
    }
}