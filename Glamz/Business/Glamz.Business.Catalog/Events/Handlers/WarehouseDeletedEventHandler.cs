using Glamz.Domain.Data;
using Glamz.Domain.Catalog;
using Glamz.Domain.Shipping;
using Glamz.Infrastructure.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Business.Catalog.Events.Handlers
{
    public class WarehouseDeletedEventHandler : INotificationHandler<EntityDeleted<Warehouse>>
    {
        private readonly IRepository<Product> _productRepository;

        public WarehouseDeletedEventHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(EntityDeleted<Warehouse> notification, CancellationToken cancellationToken)
        {
            await _productRepository.PullFilter(string.Empty, x => x.ProductWarehouseInventory, z => z.WarehouseId, notification.Entity.Id, true);

            await _productRepository.UpdateManyAsync(x => x.WarehouseId == notification.Entity.Id,
                UpdateBuilder<Product>.Create().Set(x => x.WarehouseId, ""));

        }
    }
}
