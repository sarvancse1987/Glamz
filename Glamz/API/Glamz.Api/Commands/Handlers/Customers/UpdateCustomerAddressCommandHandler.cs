﻿using Glamz.Api.Commands.Models.Customers;
using Glamz.Api.DTOs.Customers;
using Glamz.Api.Extensions;
using Glamz.Business.Customers.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Commands.Handlers.Customers
{
    public class UpdateCustomerAddressCommandHandler : IRequestHandler<UpdateCustomerAddressCommand, AddressDto>
    {
        private readonly ICustomerService _customerService;

        public UpdateCustomerAddressCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<AddressDto> Handle(UpdateCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerService.GetCustomerById(request.Customer.Id);
            if (customer != null)
            {
                var address = customer.Addresses.FirstOrDefault(x => x.Id == request.Address.Id);
                if (address != null)
                {
                    address = request.Address.ToEntity(address);
                    await _customerService.UpdateAddress(address, request.Customer.Id);
                    return address.ToModel();
                }
            }
            return null;
        }
    }
}
