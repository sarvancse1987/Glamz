using Glamz.Api.DTOs.Customers;
using Glamz.Api.Queries.Models.Common;
using Glamz.Domain.Data;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Queries.Handlers.Customers
{
    public class GetVendorQueryHandler : IRequestHandler<GetQuery<VendorDto>, IQueryable<VendorDto>>
    {
        private readonly IDatabaseContext _dbContext;

        public GetVendorQueryHandler(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IQueryable<VendorDto>> Handle(GetQuery<VendorDto> request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Table<VendorDto>(typeof(Domain.Vendors.Vendor).Name);

            if (string.IsNullOrEmpty(request.Id))
                return query;
            else
                return await Task.FromResult(query.Where(x => x.Id == request.Id));

        }
    }
}
