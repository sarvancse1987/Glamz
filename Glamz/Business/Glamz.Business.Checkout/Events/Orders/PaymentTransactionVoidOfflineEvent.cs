using Glamz.Domain.Payments;
using MediatR;

namespace Glamz.Business.Checkout.Events.Orders
{
    /// <summary>
    /// Order void offline event
    /// </summary>
    public class PaymentTransactionVoidOfflineEvent : INotification
    {
        public PaymentTransactionVoidOfflineEvent(PaymentTransaction paymentTransaction)
        {
            PaymentTransaction = paymentTransaction;
        }

        /// <summary>
        /// Order
        /// </summary>
        public PaymentTransaction PaymentTransaction { get; private set; }
    }
}
