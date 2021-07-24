using Glamz.Domain.Orders;
using MediatR;

namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public Order Order { get; set; }
    }
}
