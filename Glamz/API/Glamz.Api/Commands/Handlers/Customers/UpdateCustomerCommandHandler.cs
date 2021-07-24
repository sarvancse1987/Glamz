﻿using Glamz.Api.Commands.Models.Customers;
using Glamz.Api.DTOs.Customers;
using Glamz.Api.Extensions;
using Glamz.Business.Common.Interfaces.Directory;
using Glamz.Business.Common.Interfaces.Localization;
using Glamz.Business.Common.Interfaces.Logging;
using Glamz.Business.Customers.Interfaces;
using Glamz.Domain.Customers;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Commands.Handlers.Customers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerService _customerService;
        private readonly IGroupService _groupService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ITranslationService _translationService;
        private readonly IUserFieldService _userFieldsService;

        public UpdateCustomerCommandHandler(
            ICustomerService customerService,
            IGroupService groupService,
            ICustomerActivityService customerActivityService,
            ITranslationService translationService,
            IUserFieldService userFieldsService)
        {
            _customerService = customerService;
            _groupService = groupService;
            _customerActivityService = customerActivityService;
            _translationService = translationService;
            _userFieldsService = userFieldsService;
        }

        public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerService.GetCustomerById(request.Model.Id);
            customer = request.Model.ToEntity(customer);
            await _customerService.UpdateCustomer(customer);
            await SaveCustomerAttributes(request.Model, customer);
            await SaveCustomerGroups(request.Model, customer);

            //activity log
            await _customerActivityService.InsertActivity("EditCustomer", customer.Id, _translationService.GetResource("ActivityLog.EditCustomer"), customer.Id);

            return customer.ToModel();
        }

        protected async Task SaveCustomerAttributes(CustomerDto model, Customer customer)
        {
            await _userFieldsService.SaveField(customer, SystemCustomerFieldNames.VatNumber, model.VatNumber);
            await _userFieldsService.SaveField(customer, SystemCustomerFieldNames.VatNumberStatusId, model.VatNumberStatusId);
            await _userFieldsService.SaveField(customer, SystemCustomerFieldNames.Gender, model.Gender);
            await _userFieldsService.SaveField(customer, SystemCustomerFieldNames.FirstName, model.FirstName);
            await _userFieldsService.SaveField(customer, SystemCustomerFieldNames.LastName, model.LastName);
            await _userFieldsService.SaveField(customer, SystemCustomerFieldNames.DateOfBirth, model.DateOfBirth);
            await _userFieldsService.SaveField(customer, SystemCustomerFieldNames.Company, model.Company);
            await _userFieldsService.SaveField(customer, SystemCustomerFieldNames.StreetAddress, model.StreetAddress);
            await _userFieldsService.SaveField(customer, SystemCustomerFieldNames.StreetAddress2, model.StreetAddress2);
            await _userFieldsService.SaveField(customer, SystemCustomerFieldNames.ZipPostalCode, model.ZipPostalCode);
            await _userFieldsService.SaveField(customer, SystemCustomerFieldNames.City, model.City);
            await _userFieldsService.SaveField(customer, SystemCustomerFieldNames.CountryId, model.CountryId);
            await _userFieldsService.SaveField(customer, SystemCustomerFieldNames.StateProvinceId, model.StateProvinceId);
            await _userFieldsService.SaveField(customer, SystemCustomerFieldNames.Phone, model.Phone);
            await _userFieldsService.SaveField(customer, SystemCustomerFieldNames.Fax, model.Fax);
        }

        protected async Task SaveCustomerGroups(CustomerDto model, Customer customer)
        {
            var insertgroup = model.Groups.Except(customer.Groups.Select(x => x)).ToList();
            foreach (var item in insertgroup)
            {
                var group = await _groupService.GetCustomerGroupById(item);
                if (group != null)
                {
                    customer.Groups.Add(item);
                    await _customerService.InsertCustomerGroupInCustomer(group, customer.Id);
                }
            }
            var deletegroup = customer.Groups.Select(x => x).Except(model.Groups).ToList();
            foreach (var item in deletegroup)
            {
                var group = await _groupService.GetCustomerGroupById(item);
                if (group != null)
                {
                    customer.Groups.Remove(customer.Groups.FirstOrDefault(x => x == item));
                    await _customerService.DeleteCustomerGroupInCustomer(group, customer.Id);
                }
            }
        }
    }
}