using Glamz.Domain.Shipping;
using MediatR;

namespace Glamz.Business.Checkout.Commands.Models.Shipping
{
    public class DeliveryCommand : IRequest<bool>
    {
        public Shipment Shipment { get; set; }
        public bool NotifyCustomer { get; set; }
    }
}
