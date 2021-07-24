using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class AddProductAttributeMappingCommand : IRequest<ProductAttributeMappingDto>
    {
        public ProductDto Product { get; set; }
        public ProductAttributeMappingDto Model { get; set; }
    }
}
