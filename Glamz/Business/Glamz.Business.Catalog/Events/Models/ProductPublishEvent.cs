using Glamz.Domain.Catalog;
using MediatR;

namespace Glamz.Business.Catalog.Events.Models
{
    public class ProductPublishEvent : INotification
    {
        public ProductPublishEvent(Product product)
        {
            Product = product;
        }

        public Product Product { get; private set; }
    }
}
