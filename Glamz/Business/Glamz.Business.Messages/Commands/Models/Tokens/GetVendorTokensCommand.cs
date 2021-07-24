using Glamz.Domain.Localization;
using Glamz.Domain.Vendors;
using Glamz.Business.Messages.DotLiquidDrops;
using MediatR;

namespace Glamz.Business.Messages.Commands.Models
{
    public class GetVendorTokensCommand : IRequest<LiquidVendor>
    {
        public Vendor Vendor { get; set; }
        public Language Language { get; set; }
    }
}
