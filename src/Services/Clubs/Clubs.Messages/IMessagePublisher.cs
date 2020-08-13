

using System.Threading.Tasks;

namespace Clubs.Messages
{
    public interface IMessagePublisher
    {
        Task Publish<T>(T obj);

        Task Publish(string raw);
    }
}