using Glamz.Domain.Orders;
using MediatR;

namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class ActivatedValueForPurchasedGiftVouchersCommand : IRequest<bool>
    {
        public Order Order { get; set; }
        public bool Activate { get; set; }
    }
}
