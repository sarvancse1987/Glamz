using Glamz.Domain.Catalog;
using MediatR;
using System.Collections.Generic;

namespace Glamz.Business.Messages.Queries.Models
{
    public class GetBidsByProductIdQuery : IRequest<IList<Bid>>
    {
        public string ProductId { get; set; }
    }
}
