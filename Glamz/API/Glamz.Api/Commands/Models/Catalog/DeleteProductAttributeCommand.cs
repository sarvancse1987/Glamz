using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class DeleteProductAttributeCommand : IRequest<bool>
    {
        public ProductAttributeDto Model { get; set; }
    }
}
