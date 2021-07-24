using Glamz.Domain.Catalog;
using Glamz.Business.Messages.DotLiquidDrops;
using MediatR;

namespace Glamz.Business.Messages.Commands.Models
{
    public class GetAuctionTokensCommand : IRequest<LiquidAuctions>
    {
        public Product Product { get; set; }
        public Bid Bid { get; set; }
    }
}
