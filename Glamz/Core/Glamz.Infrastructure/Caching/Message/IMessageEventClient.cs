﻿
namespace Glamz.Infrastructure.Caching.Message
{
    public interface IMessageEventClient : IMessageEvent
    {
        string ClientId { get; set; }
    }
}
