using Glamz.Domain.Customers;
using MediatR;

namespace Glamz.Business.Customers.Queries.Models
{
    public class GetPasswordIsExpiredQuery : IRequest<bool>
    {
        public Customer Customer { get; set; }
    }
}
