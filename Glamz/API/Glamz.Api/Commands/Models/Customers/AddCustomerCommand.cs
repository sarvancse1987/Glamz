using Glamz.Api.DTOs.Customers;
using MediatR;

namespace Glamz.Api.Commands.Models.Customers
{
    public class AddCustomerCommand : IRequest<CustomerDto>
    {
        public CustomerDto Model { get; set; }
    }
}
