﻿using Glamz.Domain.Orders;
using MediatR;

namespace Glamz.Business.Checkout.Events.Orders
{
    /// <summary>
    /// Order deleted event
    /// </summary>
    public class OrderDeletedEvent : INotification
    {
        public OrderDeletedEvent(Order order)
        {
            Order = order;
        }

        /// <summary>
        /// Order
        /// </summary>
        public Order Order { get; private set; }
    }
}
