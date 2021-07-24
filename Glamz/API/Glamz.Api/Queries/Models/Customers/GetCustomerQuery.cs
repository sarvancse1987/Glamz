using Glamz.Api.DTOs.Customers;
using MediatR;

namespace Glamz.Api.Queries.Models.Customers
{
    public class GetCustomerQuery : IRequest<CustomerDto>
    {
        public string Email { get; set; }
    }
}
