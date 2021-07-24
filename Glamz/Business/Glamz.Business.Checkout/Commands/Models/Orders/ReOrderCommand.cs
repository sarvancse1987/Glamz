using Glamz.Domain.Orders;
using MediatR;
using System.Collections.Generic;

namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class ReOrderCommand : IRequest<IList<string>>
    {
        public Order Order { get; set; }
    }
}
