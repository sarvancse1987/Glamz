using Glamz.Domain.Orders;
using MediatR;

namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class SetOrderStatusCommand : IRequest<bool>
    {
        public Order Order { get; set; }
        public OrderStatusSystem Os { get; set; }
        public bool NotifyCustomer { get; set; }
        public bool NotifyStoreOwner { get; set; }
    }
}
