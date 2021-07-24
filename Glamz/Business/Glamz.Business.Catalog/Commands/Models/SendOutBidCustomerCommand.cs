using Glamz.Domain.Catalog;
using Glamz.Domain.Localization;
using MediatR;

namespace Glamz.Business.Catalog.Commands.Models
{
    public class SendOutBidCustomerCommand : IRequest<bool>
    {
        public Product Product { get; set; }
        public Bid Bid { get; set; }
        public Language Language { get; set; }
    }
}
