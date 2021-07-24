using Glamz.Business.Checkout.Events.Orders;
using Glamz.Business.Marketing.Interfaces.Customers;
using Glamz.Domain.Customers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Business.Marketing.Events
{
    public class OrderPaidEventHandler : INotificationHandler<OrderPaidEvent>
    {
        private readonly ICustomerActionEventService _customerActionEventService;

        public OrderPaidEventHandler(ICustomerActionEventService customerActionEventService)
        {
            _customerActionEventService = customerActionEventService;
        }

        public async Task Handle(OrderPaidEvent notification, CancellationToken cancellationToken)
        {
            //customer action event service - paid order
            await _customerActionEventService.AddOrder(notification.Order, CustomerActionTypeEnum.PaidOrder);
        }
    }
}
