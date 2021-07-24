using Glamz.Domain.Shipping;
using MediatR;

namespace Glamz.Business.Checkout.Queries.Models.Orders
{
    public class GetPickupPointById : IRequest<PickupPoint>
    {
        public string Id { get; set; }
    }
}
