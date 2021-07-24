using Glamz.Api.Commands.Models.Customers;
using Glamz.Api.DTOs.Customers;
using Glamz.Api.Extensions;
using Glamz.Business.Customers.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Commands.Handlers.Customers
{
    public class AddCustomerAddressCommandHandler : IRequestHandler<AddCustomerAddressCommand, AddressDto>
    {
        private readonly ICustomerService _customerService;

        public AddCustomerAddressCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<AddressDto> Handle(AddCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var address = request.Address.ToEntity();
            address.CreatedOnUtc = DateTime.UtcNow;
            address.Id = "";
            await _customerService.InsertAddress(address, request.Customer.Id);
            return address.ToModel();
        }
    }
}
