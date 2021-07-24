using System.Threading.Tasks;

namespace Glamz.Infrastructure.Caching.Message
{
    public interface IMessageSubscriber
    {
        Task SubscribeAsync();
    }
}
