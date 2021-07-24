using Glamz.Api.Commands.Models.Catalog;
using Glamz.Api.DTOs.Catalog;
using Glamz.Api.Extensions;
using Glamz.Business.Catalog.Interfaces.Products;
using Glamz.Business.Common.Interfaces.Localization;
using Glamz.Business.Common.Interfaces.Logging;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Commands.Handlers.Catalog
{
    public class UpdateProductAttributeCommandHandler : IRequestHandler<UpdateProductAttributeCommand, ProductAttributeDto>
    {
        private readonly IProductAttributeService _productAttributeService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ITranslationService _translationService;

        public UpdateProductAttributeCommandHandler(
            IProductAttributeService productAttributeService,
            ICustomerActivityService customerActivityService,
            ITranslationService translationService)
        {
            _productAttributeService = productAttributeService;
            _customerActivityService = customerActivityService;
            _translationService = translationService;
        }

        public async Task<ProductAttributeDto> Handle(UpdateProductAttributeCommand request, CancellationToken cancellationToken)
        {
            var productAttribute = await _productAttributeService.GetProductAttributeById(request.Model.Id);

            productAttribute = request.Model.ToEntity(productAttribute);
            await _productAttributeService.UpdateProductAttribute(productAttribute);

            //activity log
            await _customerActivityService.InsertActivity("EditProductAttribute", productAttribute.Id,
                _translationService.GetResource("ActivityLog.EditProductAttribute"), productAttribute.Name);

            return productAttribute.ToModel();
        }
    }
}
