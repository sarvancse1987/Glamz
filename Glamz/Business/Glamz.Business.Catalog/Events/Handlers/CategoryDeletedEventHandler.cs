using Glamz.Domain.Catalog;
using Glamz.Domain.Data;
using Glamz.Domain.Seo;
using Glamz.Infrastructure.Caching;
using Glamz.Infrastructure.Caching.Constants;
using Glamz.Infrastructure.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Business.Catalog.Events.Handlers
{
    public class CategoryDeletedEventHandler : INotificationHandler<EntityDeleted<Category>>
    {
        private readonly IRepository<EntityUrl> _entityUrlRepository;
        private readonly IRepository<Product> _productRepository;

        private readonly ICacheBase _cacheBase;

        public CategoryDeletedEventHandler(
            IRepository<EntityUrl> entityUrlRepository,
            IRepository<Product> productRepository,
            ICacheBase cacheBase)
        {
            _entityUrlRepository = entityUrlRepository;
            _productRepository = productRepository;

            _cacheBase = cacheBase;
        }

        public async Task Handle(EntityDeleted<Category> notification, CancellationToken cancellationToken)
        {
            //delete url
            await _entityUrlRepository.DeleteManyAsync(x => x.EntityId == notification.Entity.Id && x.EntityName == "Category");

            //delete on the product
            await _productRepository.PullFilter(string.Empty, x => x.ProductCategories, z => z.CategoryId, notification.Entity.Id, true);

            //clear cache
            await _cacheBase.RemoveByPrefix(CacheKey.PRODUCTS_PATTERN_KEY);

        }
    }
}