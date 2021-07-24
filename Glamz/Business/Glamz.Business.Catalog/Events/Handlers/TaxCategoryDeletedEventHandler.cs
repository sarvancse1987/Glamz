﻿using Glamz.Domain.Data;
using Glamz.Domain.Catalog;
using Glamz.Domain.Tax;
using Glamz.Infrastructure.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Business.Catalog.Events.Handlers
{
    public class TaxCategoryDeletedEventHandler : INotificationHandler<EntityDeleted<TaxCategory>>
    {
        private readonly IRepository<Product> _productRepository;

        public TaxCategoryDeletedEventHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(EntityDeleted<TaxCategory> notification, CancellationToken cancellationToken)
        {
            await _productRepository.UpdateManyAsync(x => x.TaxCategoryId == notification.Entity.Id,
                UpdateBuilder<Product>.Create().Set(x => x.TaxCategoryId, ""));
        }
    }
}
