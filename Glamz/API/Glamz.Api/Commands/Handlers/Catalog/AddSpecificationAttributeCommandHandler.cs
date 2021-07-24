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
    public class AddSpecificationAttributeCommandHandler : IRequestHandler<AddSpecificationAttributeCommand, SpecificationAttributeDto>
    {
        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ITranslationService _translationService;

        public AddSpecificationAttributeCommandHandler(
            ISpecificationAttributeService specificationAttributeService,
            ICustomerActivityService customerActivityService,
            ITranslationService translationService)
        {
            _specificationAttributeService = specificationAttributeService;
            _customerActivityService = customerActivityService;
            _translationService = translationService;
        }

        public async Task<SpecificationAttributeDto> Handle(AddSpecificationAttributeCommand request, CancellationToken cancellationToken)
        {
            var specificationAttribute = request.Model.ToEntity();
            await _specificationAttributeService.InsertSpecificationAttribute(specificationAttribute);

            //activity log
            await _customerActivityService.InsertActivity("AddNewSpecAttribute", specificationAttribute.Id, _translationService.GetResource("ActivityLog.AddNewSpecAttribute"), specificationAttribute.Name);

            return specificationAttribute.ToModel();
        }
    }
}
