using Glamz.Domain.Payments;
using MediatR;
using System.Collections.Generic;

namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class PartiallyRefundCommand : IRequest<IList<string>>
    {
        public PaymentTransaction PaymentTransaction { get; set; }
        public double AmountToRefund { get; set; }
    }
}
