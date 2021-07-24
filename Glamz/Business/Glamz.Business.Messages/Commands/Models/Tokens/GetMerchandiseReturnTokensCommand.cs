using Glamz.Domain.Localization;
using Glamz.Domain.Orders;
using Glamz.Domain.Stores;
using Glamz.Business.Messages.DotLiquidDrops;
using MediatR;

namespace Glamz.Business.Messages.Commands.Models
{
    public class GetMerchandiseReturnTokensCommand : IRequest<LiquidMerchandiseReturn>
    {
        public MerchandiseReturn MerchandiseReturn { get; set; }
        public Store Store { get; set; }
        public Order Order { get; set; }
        public Language Language { get; set; }
        public MerchandiseReturnNote MerchandiseReturnNote { get; set; } = null;
    }
}
