using Glamz.Domain.Customers;
using Glamz.Domain.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class ValidateMinShoppingCartSubtotalAmountCommand : IRequest<bool>
    {
        public Customer Customer { get; set; }
        public IList<ShoppingCartItem> Cart { get; set; }
    }
}
