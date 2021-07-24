using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class AddProductTierPriceCommand : IRequest<bool>
    {
        public ProductDto Product { get; set; }
        public ProductTierPriceDto Model { get; set; }
    }
}
