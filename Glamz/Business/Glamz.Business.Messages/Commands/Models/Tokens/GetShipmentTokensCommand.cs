using Glamz.Domain.Localization;
using Glamz.Domain.Orders;
using Glamz.Domain.Shipping;
using Glamz.Domain.Stores;
using Glamz.Business.Messages.DotLiquidDrops;
using MediatR;

namespace Glamz.Business.Messages.Commands.Models
{
    public class GetShipmentTokensCommand : IRequest<LiquidShipment>
    {
        public Shipment Shipment { get; set; }
        public Order Order { get; set; }
        public Store Store { get; set; }
        public Language Language { get; set; }
    }
}
