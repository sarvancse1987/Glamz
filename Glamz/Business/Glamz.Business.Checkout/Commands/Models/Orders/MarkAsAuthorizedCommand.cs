using Glamz.Domain.Payments;
using MediatR;

namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class MarkAsAuthorizedCommand : IRequest<bool>
    {
        public PaymentTransaction PaymentTransaction { get; set; }
    }
}
