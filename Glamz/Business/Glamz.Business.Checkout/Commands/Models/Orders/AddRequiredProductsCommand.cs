using Glamz.Domain.Catalog;
using Glamz.Domain.Customers;
using Glamz.Domain.Orders;
using MediatR;

namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class AddRequiredProductsCommand : IRequest<bool>
    {
        public Customer Customer { get; set; }
        public ShoppingCartType ShoppingCartType { get; set; }
        public Product Product { get; set; }
        public string StoreId { get; set; }
    }
}
