using Glamz.Api.DTOs.Customers;
using Glamz.Api.Extensions;
using Glamz.Business.Common.Interfaces.Directory;
using Glamz.Business.Common.Interfaces.Localization;
using Glamz.Business.Common.Interfaces.Logging;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Commands.Models.Customers
{
    public class UpdateCustomerGroupCommandHandler : IRequestHandler<UpdateCustomerGroupCommand, CustomerGroupDto>
    {
        private readonly IGroupService _groupService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ITranslationService _translationService;

        public UpdateCustomerGroupCommandHandler(
            IGroupService groupService,
            ICustomerActivityService customerActivityService,
            ITranslationService translationService)
        {
            _groupService = groupService;
            _customerActivityService = customerActivityService;
            _translationService = translationService;
        }

        public async Task<CustomerGroupDto> Handle(UpdateCustomerGroupCommand request, CancellationToken cancellationToken)
        {
            var customerGroup = await _groupService.GetCustomerGroupById(request.Model.Id);
            customerGroup = request.Model.ToEntity(customerGroup);
            await _groupService.UpdateCustomerGroup(customerGroup);

            //activity log
            await _customerActivityService.InsertActivity("EditCustomerGroup", customerGroup.Id, _translationService.GetResource("ActivityLog.EditCustomerGroup"), customerGroup.Name);

            return customerGroup.ToModel();
        }
    }
}
