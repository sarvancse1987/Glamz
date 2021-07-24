﻿using FluentValidation;
using Glamz.Api.DTOs.Customers;
using Glamz.Business.Common.Interfaces.Directory;
using Glamz.Business.Common.Interfaces.Localization;
using Glamz.Infrastructure.Validators;
using System;
using System.Collections.Generic;

namespace Glamz.Api.Validators.Customers
{
    public class CustomerGroupValidator : BaseGrandValidator<CustomerGroupDto>
    {
        public CustomerGroupValidator(
            IEnumerable<IValidatorConsumer<CustomerGroupDto>> validators,
            ITranslationService translationService, IGroupService groupService)
            : base(validators)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(translationService.GetResource("Api.Customers.CustomerGroup.Fields.Name.Required"));

            RuleFor(x => x).MustAsync(async (x, context) =>
            {
                if (!string.IsNullOrEmpty(x.Id))
                {
                    var group = await groupService.GetCustomerGroupById(x.Id);
                    if (group == null)
                        return false;
                }
                return true;
            }).WithMessage(translationService.GetResource("Api.Customers.CustomerGroup.Fields.Id.NotExists"));
            RuleFor(x => x).MustAsync(async (x, context) =>
            {
                if (!string.IsNullOrEmpty(x.Id))
                {
                    var customerGroup = await groupService.GetCustomerGroupById(x.Id);
                    if (customerGroup.IsSystem && !x.Active)
                    {
                        return false;
                    }
                }
                return true;
            }).WithMessage(translationService.GetResource("Api.Customers.CustomerGroup.Fields.Active.CantEditSystem"));
            RuleFor(x => x).MustAsync(async (x, context) =>
            {
                if (!string.IsNullOrEmpty(x.Id))
                {
                    var customerGroup = await groupService.GetCustomerGroupById(x.Id);
                    if (customerGroup.IsSystem && !customerGroup.SystemName.Equals(x.SystemName, StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                }
                return true;
            }).WithMessage(translationService.GetResource("Api.Customers.CustomerGroup.Fields.SystemName.CantEditSystem"));
        }
    }
}
