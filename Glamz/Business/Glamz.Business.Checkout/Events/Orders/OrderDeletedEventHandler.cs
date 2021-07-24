﻿using Glamz.Domain.Catalog;
using Glamz.Domain.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Business.Checkout.Events.Orders
{
    public class OrderDeletedEventHandler : INotificationHandler<OrderDeletedEvent>
    {
        private readonly IRepository<ProductAlsoPurchased> _productAlsoPurchasedRepository;

        public OrderDeletedEventHandler(IRepository<ProductAlsoPurchased> productAlsoPurchasedRepository)
        {
            _productAlsoPurchasedRepository = productAlsoPurchasedRepository;
        }

        public Task Handle(OrderDeletedEvent notification, CancellationToken cancellationToken)
        {
            //delete product also purchased
            return _productAlsoPurchasedRepository.DeleteManyAsync(x=>x.OrderId == notification.Order.Id);
        }
    }
}
