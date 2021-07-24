using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class DeleteBrandCommand : IRequest<bool>
    {
        public BrandDto Model { get; set; }
    }
}
