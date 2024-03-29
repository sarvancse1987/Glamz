﻿using System.Threading.Tasks;

namespace Glamz.Infrastructure.Caching.Message
{
    public interface IMessageBus : IMessagePublisher, IMessageSubscriber
    {
        Task OnSubscriptionChanged(IMessageEvent message);
    }
}
