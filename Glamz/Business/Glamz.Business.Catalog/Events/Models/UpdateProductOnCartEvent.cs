using Glamz.Domain.Catalog;
using MediatR;

namespace Glamz.Business.Catalog.Events.Models
{
    public class UpdateProductOnCartEvent : INotification
    {
        private readonly Product _product;

        public UpdateProductOnCartEvent(Product product)
        {
            _product = product;
        }

        public Product Product { get { return _product; } }

    }
}
