using DotLiquid;
using Glamz.Business.Messages.Events;
using Glamz.Domain;
using Glamz.Domain.Messages;
using MediatR;
using System.Threading.Tasks;

namespace Glamz.Business.Messages.Extensions
{
    public static class MessagesEventPublisherExtensions
    {
        public static async Task EntityTokensAdded<T>(this IMediator mediator, T entity, Drop liquidDrop, LiquidObject liquidObject) where T : ParentEntity
        {
            await mediator.Publish(new EntityTokensAddedEvent<T>(entity, liquidDrop, liquidObject));
        }

        public static async Task MessageTokensAdded(this IMediator mediator, MessageTemplate message, LiquidObject liquidObject)
        {
            await mediator.Publish(new MessageTokensAddedEvent(message, liquidObject));
        }
    }
}
