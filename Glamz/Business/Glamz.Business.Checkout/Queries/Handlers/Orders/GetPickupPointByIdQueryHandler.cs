using Glamz.Business.Checkout.Interfaces.Shipping;
using Glamz.Business.Checkout.Queries.Models.Orders;
using Glamz.Domain.Shipping;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Business.Checkout.Queries.Handlers.Orders
{
    public class GetPickupPointByIdQueryHandler : IRequestHandler<GetPickupPointById, PickupPoint>
    {
        private readonly IPickupPointService _pickupPointService;
        public GetPickupPointByIdQueryHandler(IPickupPointService pickupPointService)
        {
            _pickupPointService = pickupPointService;
        }
        public async Task<PickupPoint> Handle(GetPickupPointById request, CancellationToken cancellationToken)
        {
            return await _pickupPointService.GetPickupPointById(request.Id);
        }
    }
}
