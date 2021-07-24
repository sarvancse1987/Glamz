using Glamz.Business.Catalog.Interfaces.Collections;
using Glamz.Domain.Catalog;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class AddProductCollectionCommandHandler : IRequestHandler<AddProductCollectionCommand, bool>
    {
        private readonly IProductCollectionService _productcollectionService;

        public AddProductCollectionCommandHandler(IProductCollectionService productcollectionService)
        {
            _productcollectionService = productcollectionService;
        }

        public async Task<bool> Handle(AddProductCollectionCommand request, CancellationToken cancellationToken)
        {
            var productCollection = new ProductCollection
            {
                CollectionId = request.Model.CollectionId,
                IsFeaturedProduct = request.Model.IsFeaturedProduct,
            };
            await _productcollectionService.InsertProductCollection(productCollection, request.Product.Id);

            return true;
        }
    }
}
