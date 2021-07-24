using Glamz.Api.DTOs.Customers;
using MediatR;

namespace Glamz.Api.Commands.Models.Customers
{
    public class DeleteCustomerGroupCommand : IRequest<bool>
    {
        public CustomerGroupDto Model { get; set; }
    }
}
