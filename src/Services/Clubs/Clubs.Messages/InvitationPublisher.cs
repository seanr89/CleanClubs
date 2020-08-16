

using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Utilities;

namespace Clubs.Messages
{
    //Following: https://www.youtube.com/watch?v=gQ5P8WVpj30&t=1241s
    public class InvitationPublisher : IMessagePublisher
    {
        private readonly IQueueClient _queueClient;
        private readonly ILogger<InvitationPublisher> _logger;

        public InvitationPublisher(IQueueClient queueClient, ILogger<InvitationPublisher> logger)
        {
            _queueClient = queueClient;
            _logger = logger;
        }

        /// <summary>
        /// Support the publishing of a invite confirmation
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Task Publish<T>(T obj)
        {
            _logger.LogInformation($"InvitePublisher: {HelperMethods.GetCallerMemberName()}");

            try
            {
                var objAsText = JsonConvert.SerializeObject(obj, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                var message = new Message(Encoding.UTF8.GetBytes(objAsText));
                return _queueClient.SendAsync(message);
            }
            catch (JsonSerializationException e)
            {
                _logger.LogError($"publish exception: {e.Message}");
                return null;
            }
        }

        public Task Publish(string raw)
        {
            var message = new Message(Encoding.UTF8.GetBytes(raw));
            return _queueClient.SendAsync(message);
        }
    }
}