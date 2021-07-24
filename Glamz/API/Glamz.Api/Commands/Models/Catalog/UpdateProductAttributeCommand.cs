using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class UpdateProductAttributeCommand : IRequest<ProductAttributeDto>
    {
        public ProductAttributeDto Model { get; set; }
    }
}
