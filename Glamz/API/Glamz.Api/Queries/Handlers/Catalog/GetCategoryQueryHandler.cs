using Glamz.Api.DTOs.Catalog;
using Glamz.Api.Queries.Models.Common;
using Glamz.Domain.Data;
using Glamz.Domain.Data.Mongo;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Queries.Handlers.Common
{
    public class GetCategoryQueryHandler : IRequestHandler<GetQuery<CategoryDto>, IQueryable<CategoryDto>>
    {
        private readonly IDatabaseContext _dbContext;

        public GetCategoryQueryHandler()//IDatabaseContext dbContext
        {
            //_dbContext = dbContext;
            _dbContext = new MongoDBContext("mongodb://127.0.0.1:27017/GlamzApiTestcase");
        }
        public async Task<IQueryable<CategoryDto>> Handle(GetQuery<CategoryDto> request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Table<CategoryDto>(typeof(Domain.Catalog.Category).Name);

            if (string.IsNullOrEmpty(request.Id))
                return query;
            else
                return await Task.FromResult(query.Where(x => x.Id == request.Id));

        }
    }
}
