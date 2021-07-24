using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class AddProductCommand : IRequest<ProductDto>
    {
        public ProductDto Model { get; set; }
    }
}
