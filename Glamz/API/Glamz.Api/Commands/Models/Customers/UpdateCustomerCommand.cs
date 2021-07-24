using Glamz.Api.DTOs.Customers;
using MediatR;

namespace Glamz.Api.Commands.Models.Customers
{
    public class UpdateCustomerCommand : IRequest<CustomerDto>
    {
        public CustomerDto Model { get; set; }
    }
}
