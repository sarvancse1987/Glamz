using Glamz.Domain.Payments;
using MediatR;

namespace Glamz.Business.Checkout.Queries.Models.Orders
{
    public class CanMarkPaymentTransactionAsAuthorizedQuery : IRequest<bool>
    {
        public PaymentTransaction PaymentTransaction { get; set; }
    }
}
