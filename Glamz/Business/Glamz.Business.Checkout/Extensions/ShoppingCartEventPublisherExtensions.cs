using Glamz.Business.Checkout.Events.ShoppingCart;
using Glamz.Domain.Catalog;
using Glamz.Domain.Common;
using Glamz.Domain.Customers;
using Glamz.Domain.Orders;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glamz.Business.Checkout.Extensions
{
    public static class ShoppingCartEventPublisherExtensions
    {
        public static async Task ShoppingCartWarningsAdd<T, U>(this IMediator eventPublisher, IList<T> warnings, IList<U> shoppingCartItems, IList<CustomAttribute> checkoutAttributes, bool validateCheckoutAttributes) where U : ShoppingCartItem
        {
            await eventPublisher.Publish(new ShoppingCartWarningsEvent<T, U>(warnings, shoppingCartItems, checkoutAttributes, validateCheckoutAttributes));
        }

        public static async Task ShoppingCartItemWarningsAdded<C, S, P>(this IMediator eventPublisher, IList<string> warnings, C customer, S shoppingcartItem, P product) where C : Customer where S : ShoppingCartItem where P : Product
        {
            await eventPublisher.Publish(new ShoppingCartItemWarningsEvent<C, S, P>(warnings, customer, shoppingcartItem, product));
        }

    }
}