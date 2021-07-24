using Glamz.Domain.Orders;
using MediatR;

namespace Glamz.Business.Checkout.Queries.Models.Orders
{
    public class IsMerchandiseReturnAllowedQuery : IRequest<bool>
    {
        public Order Order { get; set; }
    }
}
