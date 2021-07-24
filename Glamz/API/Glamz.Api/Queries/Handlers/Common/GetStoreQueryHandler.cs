using Glamz.Api.DTOs.Common;
using Glamz.Api.Queries.Models.Common;
using Glamz.Domain.Data;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Queries.Handlers.Common
{
    public class GetStoreQueryHandler : IRequestHandler<GetQuery<StoreDto>, IQueryable<StoreDto>>
    {
        private readonly IDatabaseContext _dbContext;

        public GetStoreQueryHandler(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IQueryable<StoreDto>> Handle(GetQuery<StoreDto> request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Table<StoreDto>(typeof(Domain.Stores.Store).Name);

            if (string.IsNullOrEmpty(request.Id))
                return query;
            else
                return await Task.FromResult(query.Where(x => x.Id == request.Id));

        }
    }
}
