using Glamz.Domain.Payments;
using MediatR;

namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class MarkAsPaidCommand : IRequest<bool>
    {
        public PaymentTransaction PaymentTransaction { get; set; }
    }
}
