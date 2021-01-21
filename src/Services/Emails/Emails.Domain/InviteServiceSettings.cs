
namespace Emails.Domain.Settings
{
    /// <summary>
    /// Service Bus Connection AppSettings model
    /// </summary>
    public class InviteServiceSettings
    {
        public string ConnectionString { get; private set; }
        public string TopicName { get; private set; }
        public string Subscription { get; private set; }
    }
}