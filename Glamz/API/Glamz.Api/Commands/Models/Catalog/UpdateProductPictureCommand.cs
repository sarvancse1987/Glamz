using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class UpdateProductPictureCommand : IRequest<bool>
    {
        public ProductDto Product { get; set; }
        public ProductPictureDto Model { get; set; }
    }
}
