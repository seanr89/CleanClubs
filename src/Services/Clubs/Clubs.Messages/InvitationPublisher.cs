using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Utilities;
using System;

namespace Clubs.Messages
{
    //Following: https://www.youtube.com/watch?v=gQ5P8WVpj30&t=1241s
    public class InvitationPublisher : IMessagePublisher
    {
        private readonly ITopicClient _topicClient;
        private readonly ILogger<InvitationPublisher> _logger;

        public InvitationPublisher(ITopicClient topicClient, ILogger<InvitationPublisher> logger)
        {
            _topicClient = topicClient;
            _logger = logger;
        }

        /// <summary>
        /// Support the publishing of a invite confirmation message
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
                //Append message type for topic and subscription handling
                message.UserProperties["MessageType"] = typeof(T).Name;
                return _topicClient.SendAsync(message);
            }
            catch (JsonSerializationException e)
            {
                _logger.LogError($"publish jsonexception: {e.Message}");
                return null;
            }
        }

        /// <summary>
        /// Secondary raw string publish so that perhaps non-object based messages/events
        /// </summary>
        /// <param name="raw">raw string message</param>
        /// <returns></returns>
        public Task Publish(string raw)
        {
            var message = new Message(Encoding.UTF8.GetBytes(raw));
            return _topicClient.SendAsync(message);
        }
    }
}