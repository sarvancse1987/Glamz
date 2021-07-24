﻿using Glamz.Business.Catalog.Queries.Models;
using Glamz.Domain.Catalog;
using Glamz.Domain.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Business.Catalog.Queries.Handlers
{
    public class GetProductArchByIdQueryHandler : IRequestHandler<GetProductArchByIdQuery, Product>
    {
        private readonly IRepository<ProductDeleted> _productDeletedRepository;

        public GetProductArchByIdQueryHandler(IRepository<ProductDeleted> productDeletedRepository)
        {
            _productDeletedRepository = productDeletedRepository;
        }

        public async Task<Product> Handle(GetProductArchByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productDeletedRepository.GetByIdAsync(request.Id) as Product;
        }
    }
}
