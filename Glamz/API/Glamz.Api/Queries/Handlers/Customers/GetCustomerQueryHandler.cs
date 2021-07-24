using Glamz.Api.DTOs.Customers;
using Glamz.Api.Extensions;
using Glamz.Api.Queries.Models.Customers;
using Glamz.Business.Customers.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Queries.Handlers.Customers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDto>
    {
        private readonly ICustomerService _customerService;

        public GetCustomerQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            return (await _customerService.GetCustomerByEmail(request.Email)).ToModel();
        }
    }
}
