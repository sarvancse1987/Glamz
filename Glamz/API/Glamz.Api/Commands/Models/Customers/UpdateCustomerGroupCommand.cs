using Glamz.Api.DTOs.Customers;
using MediatR;

namespace Glamz.Api.Commands.Models.Customers
{
    public class UpdateCustomerGroupCommand : IRequest<CustomerGroupDto>
    {
        public CustomerGroupDto Model { get; set; }
    }
}
