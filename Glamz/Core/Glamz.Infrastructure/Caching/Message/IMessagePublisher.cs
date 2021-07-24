using System.Threading.Tasks;

namespace Glamz.Infrastructure.Caching.Message
{
    public interface IMessagePublisher
    {
        Task PublishAsync<TMessage>(TMessage msg) where TMessage : IMessageEvent;
    }
}
