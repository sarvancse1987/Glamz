using Glamz.Domain.Localization;
using Glamz.Domain.Orders;
using Glamz.Business.Messages.DotLiquidDrops;
using MediatR;

namespace Glamz.Business.Messages.Commands.Models
{
    public class GetGiftVoucherTokensCommand : IRequest<LiquidGiftVoucher>
    {
        public GiftVoucher GiftVoucher { get; set; }
        public Language Language { get; set; }
    }
}
