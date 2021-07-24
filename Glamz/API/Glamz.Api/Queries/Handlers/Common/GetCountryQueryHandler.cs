using Glamz.Api.DTOs.Common;
using Glamz.Api.Queries.Models.Common;
using Glamz.Domain.Data;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Queries.Handlers.Common
{
    public class GetCountryQueryHandler : IRequestHandler<GetQuery<CountryDto>, IQueryable<CountryDto>>
    {
        private readonly IDatabaseContext _dbContext;

        public GetCountryQueryHandler(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IQueryable<CountryDto>> Handle(GetQuery<CountryDto> request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Table<CountryDto>(typeof(Domain.Directory.Country).Name);

            if (string.IsNullOrEmpty(request.Id))
                return query;
            else
                return await Task.FromResult(query.Where(x => x.Id == request.Id));

        }
    }
}
