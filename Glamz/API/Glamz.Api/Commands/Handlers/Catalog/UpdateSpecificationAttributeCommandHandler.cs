using Glamz.Api.Commands.Models.Catalog;
using Glamz.Api.DTOs.Catalog;
using Glamz.Api.Extensions;
using Glamz.Business.Catalog.Interfaces.Products;
using Glamz.Business.Common.Interfaces.Localization;
using Glamz.Business.Common.Interfaces.Logging;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Commands.Handlers.Catalog
{
    public class UpdateSpecificationAttributeCommandHandler : IRequestHandler<UpdateSpecificationAttributeCommand, SpecificationAttributeDto>
    {
        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ITranslationService _translationService;

        public UpdateSpecificationAttributeCommandHandler(
            ISpecificationAttributeService specificationAttributeService,
            ICustomerActivityService customerActivityService,
            ITranslationService translationService)
        {
            _specificationAttributeService = specificationAttributeService;
            _customerActivityService = customerActivityService;
            _translationService = translationService;
        }

        public async Task<SpecificationAttributeDto> Handle(UpdateSpecificationAttributeCommand request, CancellationToken cancellationToken)
        {
            var specificationAttribute = await _specificationAttributeService.GetSpecificationAttributeById(request.Model.Id);
            foreach (var option in specificationAttribute.SpecificationAttributeOptions)
            {
                if (request.Model.SpecificationAttributeOptions.FirstOrDefault(x => x.Id == option.Id) == null)
                {
                    await _specificationAttributeService.DeleteSpecificationAttributeOption(option);
                }
            }
            specificationAttribute = request.Model.ToEntity(specificationAttribute);
            await _specificationAttributeService.UpdateSpecificationAttribute(specificationAttribute);

            //activity log
            await _customerActivityService.InsertActivity("EditSpecAttribute",
                specificationAttribute.Id, _translationService.GetResource("ActivityLog.EditSpecAttribute"), specificationAttribute.Name);

            return specificationAttribute.ToModel();
        }
    }
}
