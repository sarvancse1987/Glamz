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
    public class AddCustomerGroupCommandHandler : IRequestHandler<AddCustomerGroupCommand, CustomerGroupDto>
    {
        private readonly IGroupService _groupService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ITranslationService _translationService;

        public AddCustomerGroupCommandHandler(
            IGroupService groupService,
            ICustomerActivityService customerActivityService,
            ITranslationService translationService)
        {
            _groupService = groupService;
            _customerActivityService = customerActivityService;
            _translationService = translationService;
        }

        public async Task<CustomerGroupDto> Handle(AddCustomerGroupCommand request, CancellationToken cancellationToken)
        {
            var customergroup = request.Model.ToEntity();
            await _groupService.InsertCustomerGroup(customergroup);

            //activity log
            await _customerActivityService.InsertActivity("AddNewCustomerGroup", customergroup.Id, _translationService.GetResource("ActivityLog.AddNewCustomerGroup"), customergroup.Name);

            return customergroup.ToModel();
        }
    }
}
