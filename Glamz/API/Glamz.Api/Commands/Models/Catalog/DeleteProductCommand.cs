using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public ProductDto Model { get; set; }
    }
}
