using Glamz.Domain.Payments;
using MediatR;

namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class PartiallyPaidOfflineCommand : IRequest<bool>
    {
        public PaymentTransaction PaymentTransaction { get; set; }
        public double AmountToPaid { get; set; }
    }
}
