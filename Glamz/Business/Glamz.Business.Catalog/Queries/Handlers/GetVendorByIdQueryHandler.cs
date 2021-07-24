using Glamz.Business.Catalog.Queries.Models;
using Glamz.Domain.Data;
using Glamz.Domain.Vendors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Business.Catalog.Queries.Handlers
{
    public class GetVendorByIdQueryHandler : IRequestHandler<GetVendorByIdQuery, Vendor>
    {
        private readonly IRepository<Vendor> _vendorRepository;

        public GetVendorByIdQueryHandler(IRepository<Vendor> vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        public Task<Vendor> Handle(GetVendorByIdQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Id))
                return Task.FromResult<Vendor>(null);

            return _vendorRepository.GetByIdAsync(request.Id);
        }
    }
}
