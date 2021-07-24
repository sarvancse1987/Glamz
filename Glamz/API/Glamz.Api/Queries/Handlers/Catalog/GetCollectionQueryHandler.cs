using Glamz.Api.DTOs.Catalog;
using Glamz.Api.Queries.Models.Common;
using Glamz.Domain.Data;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Queries.Handlers.Common
{
    public class GetCollectionQueryHandler : IRequestHandler<GetQuery<CollectionDto>, IQueryable<CollectionDto>>
    {
        private readonly IDatabaseContext _dbContext;

        public GetCollectionQueryHandler(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<CollectionDto>> Handle(GetQuery<CollectionDto> request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Table<CollectionDto>(typeof(Domain.Catalog.Collection).Name);

            if (string.IsNullOrEmpty(request.Id))
                return query;
            else
                return await Task.FromResult(query.Where(x => x.Id == request.Id));
        }
    }
}
