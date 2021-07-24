using Glamz.Business.Catalog.Interfaces.Brands;
using Glamz.Business.Common.Interfaces.Localization;
using Glamz.Business.Common.Interfaces.Logging;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, bool>
    {
        private readonly IBrandService _brandService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ITranslationService _translationService;

        public DeleteBrandCommandHandler(
            IBrandService brandService,
            ICustomerActivityService customerActivityService,
            ITranslationService translationService)
        {
            _brandService = brandService;
            _customerActivityService = customerActivityService;
            _translationService = translationService;
        }

        public async Task<bool> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandService.GetBrandById(request.Model.Id);
            if (brand != null)
            {
                await _brandService.DeleteBrand(brand);

                //activity log
                await _customerActivityService.InsertActivity("DeleteBrand", brand.Id, _translationService.GetResource("ActivityLog.DeleteBrand"), brand.Name);
            }
            return true;
        }
    }
}
