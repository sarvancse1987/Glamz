using Glamz.Domain.Catalog;
using Glamz.Domain.Data;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Business.Messages.Queries.Models.Handlers
{
    public class GetBidsByProductIdQueryHandler : IRequestHandler<GetBidsByProductIdQuery, IList<Bid>>
    {
        private readonly IRepository<Bid> _bidRepository;

        public GetBidsByProductIdQueryHandler(IRepository<Bid> bidRepository)
        {
            _bidRepository = bidRepository;
        }

        public async Task<IList<Bid>> Handle(GetBidsByProductIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_bidRepository
                .Table.Where(x => x.ProductId == request.ProductId)
                .OrderByDescending(x => x.Date)
                .ToList());
        }
    }
}
