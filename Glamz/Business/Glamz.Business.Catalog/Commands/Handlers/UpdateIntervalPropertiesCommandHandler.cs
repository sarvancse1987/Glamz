﻿using Glamz.Business.Catalog.Commands.Models;
using Glamz.Domain.Catalog;
using Glamz.Domain.Data;
using Glamz.Infrastructure.Caching;
using Glamz.Infrastructure.Caching.Constants;
using Glamz.Infrastructure.Extensions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Business.Catalog.Commands.Handlers
{
    public class UpdateIntervalPropertiesCommandHandler : IRequestHandler<UpdateIntervalPropertiesCommand, bool>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMediator _mediator;
        private readonly ICacheBase _cacheBase;

        public UpdateIntervalPropertiesCommandHandler(IRepository<Product> productRepository, IMediator mediator, ICacheBase cacheBase)
        {
            _productRepository = productRepository;
            _mediator = mediator;
            _cacheBase = cacheBase;
        }

        public async Task<bool> Handle(UpdateIntervalPropertiesCommand request, CancellationToken cancellationToken)
        {
            if (request.Product == null)
                throw new ArgumentNullException(nameof(request.Product));

            var update = UpdateBuilder<Product>.Create()
                    .Set(x => x.Interval, request.Interval)
                    .Set(x => x.IntervalUnitId, request.IntervalUnit)
                    .Set(x => x.IncBothDate, request.IncludeBothDates);

            await _productRepository.UpdateOneAsync(x => x.Id == request.Product.Id, update);

            //cache
            await _cacheBase.RemoveByPrefix(string.Format(CacheKey.PRODUCTS_BY_ID_KEY, request.Product.Id));

            //event notification
            await _mediator.EntityUpdated(request.Product);

            return true;
        }
    }
}
