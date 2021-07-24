using Glamz.Business.Checkout.Interfaces.Orders;
using Glamz.Business.Customers.Events;
using Glamz.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Business.Checkout.Events.ShoppingCart
{
    public class CustomerLoggedInEventHandler : INotificationHandler<CustomerLoggedInEvent>
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IWorkContext _workContext;

        public CustomerLoggedInEventHandler(IShoppingCartService shoppingCartService, IWorkContext workContext)
        {
            _shoppingCartService = shoppingCartService;
            _workContext = workContext;
        }

        public async Task Handle(CustomerLoggedInEvent notification, CancellationToken cancellationToken)
        {
            //migrate shopping cart
            await _shoppingCartService.MigrateShoppingCart(_workContext.CurrentCustomer, notification.Customer, true);

        }
    }
}
