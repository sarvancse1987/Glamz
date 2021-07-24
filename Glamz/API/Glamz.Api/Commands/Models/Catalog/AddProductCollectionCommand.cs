using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class AddProductCollectionCommand : IRequest<bool>
    {
        public ProductDto Product { get; set; }
        public ProductCollectionDto Model { get; set; }
    }
}
