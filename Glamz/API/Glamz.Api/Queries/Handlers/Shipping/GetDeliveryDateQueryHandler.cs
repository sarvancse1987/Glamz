﻿using Glamz.Api.DTOs.Shipping;
using Glamz.Api.Queries.Models.Common;
using Glamz.Domain.Data;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Queries.Handlers.Shipping
{
    public class GetDeliveryDateQueryHandler : IRequestHandler<GetQuery<DeliveryDateDto>, IQueryable<DeliveryDateDto>>
    {
        private readonly IDatabaseContext _dbContext;

        public GetDeliveryDateQueryHandler(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IQueryable<DeliveryDateDto>> Handle(GetQuery<DeliveryDateDto> request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Table<DeliveryDateDto>(typeof(Domain.Shipping.DeliveryDate).Name);

            if (string.IsNullOrEmpty(request.Id))
                return query;
            else
                return await Task.FromResult(query.Where(x => x.Id == request.Id));
        }
    }
}