using Glamz.Domain.Customers;
using MediatR;

namespace Glamz.Business.Messages.Queries.Models
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public string Id { get; set; }
    }
}
