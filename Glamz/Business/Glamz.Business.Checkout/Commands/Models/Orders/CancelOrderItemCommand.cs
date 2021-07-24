using Glamz.Domain.Orders;
using MediatR;

namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class CancelOrderItemCommand : IRequest<(bool error, string message)>
    {
        public Order Order { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}
