using Glamz.Domain.Payments;
using MediatR;
using System.Collections.Generic;

namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class CaptureCommand : IRequest<IList<string>>
    {
        public PaymentTransaction PaymentTransaction { get; set; }
    }
}
