using Glamz.Domain.Payments;
using MediatR;

namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class PartiallyRefundOfflineCommand : IRequest<bool>
    {
        public PaymentTransaction PaymentTransaction { get; set; }
        public double AmountToRefund { get; set; }
    }
}
