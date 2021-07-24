using Glamz.Domain.Catalog;
using Glamz.Domain.Orders;
using MediatR;

namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class InsertOrderItemCommand : IRequest<bool>
    {
        public Order Order { get; set; }
        public OrderItem OrderItem { get; set; }
        public Product Product { get; set; }
    }
}
