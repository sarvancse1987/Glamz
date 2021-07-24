using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class DeleteProductTierPriceCommand : IRequest<bool>
    {
        public ProductDto Product { get; set; }
        public string Id { get; set; }
    }
}
