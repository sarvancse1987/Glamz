using Glamz.Domain.Customers;
using Glamz.Domain.Orders;
using MediatR;
using System.Collections.Generic;

namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class ValidateShoppingCartTotalAmountCommand : IRequest<bool>
    {
        public Customer Customer { get; set; }
        public IList<ShoppingCartItem> Cart { get; set; }
    }
}
