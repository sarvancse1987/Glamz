using Glamz.Domain.Catalog;
using MediatR;

namespace Glamz.Business.Catalog.Events.Models
{
    public class UpdateStockEvent : INotification
    {
        private readonly Product _product;

        public UpdateStockEvent(Product product)
        {
            _product = product;
        }

        public Product Result { get { return _product; } }
    }
}
