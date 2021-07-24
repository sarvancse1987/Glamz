using Glamz.Api.DTOs.Common;
using Glamz.Api.Queries.Models.Common;
using Glamz.Domain.Data;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Queries.Handlers.Common
{
    public class GetLanguageQueryHandler : IRequestHandler<GetQuery<LanguageDto>, IQueryable<LanguageDto>>
    {
        private readonly IDatabaseContext _dbContext;

        public GetLanguageQueryHandler(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IQueryable<LanguageDto>> Handle(GetQuery<LanguageDto> request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Table<LanguageDto>(typeof(Domain.Localization.Language).Name);

            if (string.IsNullOrEmpty(request.Id))
                return query;
            else
                return await Task.FromResult(query.Where(x => x.Id == request.Id));

        }
    }
}
