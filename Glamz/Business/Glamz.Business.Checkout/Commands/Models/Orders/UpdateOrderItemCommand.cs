using Glamz.Domain.Orders;
using MediatR;

namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class UpdateOrderItemCommand : IRequest<bool>
    {
        public Order Order { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}
