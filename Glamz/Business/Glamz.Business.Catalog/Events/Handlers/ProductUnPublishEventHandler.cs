﻿using Glamz.Business.Catalog.Events.Models;
using Glamz.Infrastructure.Caching;
using Glamz.Infrastructure.Caching.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Business.Catalog.Events.Handlers
{
    public class ProductUnPublishEventHandler : INotificationHandler<ProductUnPublishEvent>
    {
        private readonly ICacheBase _cacheBase;

        public ProductUnPublishEventHandler(ICacheBase cacheBase)
        {
            _cacheBase = cacheBase;
        }

        public async Task Handle(ProductUnPublishEvent notification, CancellationToken cancellationToken)
        {
            if (notification.Product.ShowOnHomePage)
                await _cacheBase.RemoveByPrefix(CacheKey.PRODUCTS_SHOWONHOMEPAGE);
        }
    }
}
