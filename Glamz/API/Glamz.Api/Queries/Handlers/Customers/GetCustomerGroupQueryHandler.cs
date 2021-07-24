using Glamz.Api.DTOs.Customers;
using Glamz.Api.Queries.Models.Common;
using Glamz.Domain.Data;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Queries.Handlers.Customers
{
    public class GetCustomerGroupQueryHandler : IRequestHandler<GetQuery<CustomerGroupDto>, IQueryable<CustomerGroupDto>>
    {
        private readonly IDatabaseContext _dbContext;

        public GetCustomerGroupQueryHandler(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IQueryable<CustomerGroupDto>> Handle(GetQuery<CustomerGroupDto> request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Table<CustomerGroupDto>(typeof(Domain.Customers.CustomerGroup).Name);

            if (string.IsNullOrEmpty(request.Id))
                return query;
            else
                return await Task.FromResult(query.Where(x => x.Id == request.Id));

        }
    }
}
