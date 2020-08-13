

using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace Clubs.Messages
{
    //Following: https://www.youtube.com/watch?v=gQ5P8WVpj30&t=1241s
    public class InvitationPublisher : IMessagePublisher
    {
        private readonly IQueueClient _queueClient;

        public InvitationPublisher(IQueueClient queueClient)
        {
            _queueClient = queueClient;
        }

        public Task Publish<T>(T obj)
        {
            var objAsText = JsonConvert.SerializeObject(obj);
            var message = new Message(Encoding.UTF8.GetBytes(objAsText));
            return _queueClient.SendAsync(message);
        }

        public Task Publish(string raw)
        {
            var message = new Message(Encoding.UTF8.GetBytes(raw));
            return _queueClient.SendAsync(message);
        }
    }
}