using Glamz.Api.DTOs.Shipping;
using Glamz.Api.Queries.Models.Common;
using Glamz.Domain.Data;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Queries.Handlers.Shipping
{
    public class GetShippingMethodQueryHandler : IRequestHandler<GetQuery<ShippingMethodDto>, IQueryable<ShippingMethodDto>>
    {
        private readonly IDatabaseContext _dbContext;

        public GetShippingMethodQueryHandler(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IQueryable<ShippingMethodDto>> Handle(GetQuery<ShippingMethodDto> request, CancellationToken cancellationToken)
        {
            var shippingMethod = _dbContext.Table<ShippingMethodDto>(typeof(Domain.Shipping.ShippingMethod).Name);

            if (string.IsNullOrEmpty(request.Id))
                return shippingMethod;
            else
                return await Task.FromResult(shippingMethod.Where(x => x.Id == request.Id));
        }
    }
}