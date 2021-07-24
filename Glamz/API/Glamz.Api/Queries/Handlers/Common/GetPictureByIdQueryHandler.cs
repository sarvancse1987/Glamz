using Glamz.Api.DTOs.Common;
using Glamz.Api.Queries.Models.Common;
using Glamz.Domain.Data;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Queries.Handlers.Common
{
    public class GetPictureByIdQueryHandler : IRequestHandler<GetPictureByIdQuery, PictureDto>
    {
        private readonly IDatabaseContext _dbContext;

        public GetPictureByIdQueryHandler(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PictureDto> Handle(GetPictureByIdQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Table<PictureDto>(typeof(Domain.Media.Picture).Name);
            return await Task.FromResult(query.Where(x => x.Id == request.Id).FirstOrDefault());
        }
    }
}
