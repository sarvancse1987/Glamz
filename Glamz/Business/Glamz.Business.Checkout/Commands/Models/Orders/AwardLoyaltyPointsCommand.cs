using Glamz.Domain.Orders;
using MediatR;

namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class AwardLoyaltyPointsCommand : IRequest<bool>
    {
        public Order Order { get; set; }
    }
}
