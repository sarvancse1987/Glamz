using Glamz.Business.Checkout.Queries.Models.Orders;
using Glamz.Domain.Orders;
using Glamz.Domain.Payments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Business.Checkout.Queries.Handlers.Orders
{
    public class CanMarkPaymentTransactionAsAuthorizedQueryHandler : IRequestHandler<CanMarkPaymentTransactionAsAuthorizedQuery, bool>
    {
        public Task<bool> Handle(CanMarkPaymentTransactionAsAuthorizedQuery request, CancellationToken cancellationToken)
        {
            var paymentTransaction = request.PaymentTransaction;
            if (paymentTransaction == null)
                throw new ArgumentNullException(nameof(request.PaymentTransaction));

            if (paymentTransaction.TransactionStatus == TransactionStatus.Canceled)
                return Task.FromResult(false);

            if (paymentTransaction.TransactionStatus == TransactionStatus.Pending)
                return Task.FromResult(true);

            return Task.FromResult(false);
        }
    }
}
