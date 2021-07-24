using Glamz.Domain.Vendors;
using MediatR;

namespace Glamz.Business.Messages.Queries.Models
{
    public class GetVendorByIdQuery : IRequest<Vendor>
    {
        public string Id { get; set; }
    }
}
