
namespace Clubs.Domain.Settings
{
    /// <summary>
    /// Service Bus Connection AppSettings model
    /// </summary>
    public class InviteServiceSettings
    {
        public string ConnectionString { get; set; }
        public string TopicName { get; set; }
        public string Subscription { get; set; }
    }
}