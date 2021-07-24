using Glamz.Domain.Customers;
using MediatR;

namespace Glamz.Business.Customers.Queries.Models
{
    public class GetGroupBySystemNameQuery : IRequest<CustomerGroup>
    {
        public string SystemName { get; set; } = "";
    }
}
