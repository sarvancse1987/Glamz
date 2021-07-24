using Glamz.Domain.Orders;
using MediatR;
namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class ReturnBackRedeemedLoyaltyPointsCommand : IRequest<bool>
    {
        public Order Order { get; set; }
    }
}
