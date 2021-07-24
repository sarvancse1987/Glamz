using Glamz.Business.Checkout.Events.Orders;
using Glamz.Business.Checkout.Utilities;
using Glamz.Domain.Payments;
using MediatR;
using System.Threading.Tasks;

namespace Glamz.Business.Checkout.Extensions
{
    public static class OrderEventPublisherExtensions
    {
        public static async Task PlaceOrderDetailsEvent<R, O>(this IMediator eventPublisher, R result, O order) where R : PlaceOrderResult where O : PlaceOrderContainter
        {
            await eventPublisher.Publish(new PlaceOrderDetailsEvent<R, O>(result, order));
        }
        public static async Task CapturePaymentTransactionDetailsEvent<R, C>(this IMediator eventPublisher, R result, C request) where R : CapturePaymentResult where C : PaymentTransaction
        {
            await eventPublisher.Publish(new CapturePaymentTransactionDetailsEvent<R, C>(result, request));
        }
        public static async Task VoidPaymentTransactionDetailsEvent<R, C>(this IMediator eventPublisher, R result, C request) where R : VoidPaymentResult where C : PaymentTransaction
        {
            await eventPublisher.Publish(new VoidPaymentTransactionDetailsEvent<R, C>(result, request));
        }
    }
}