using Glamz.Domain.Orders;
using Glamz.Domain.Vendors;
using MediatR;
using System.Collections.Generic;

namespace Glamz.Business.Checkout.Queries.Models.Orders
{
    public class GetVendorsInOrderQuery : IRequest<IList<Vendor>>
    {
        public Order Order { get; set; }
    }
}
