using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class AddBrandCommand : IRequest<BrandDto>
    {
        public BrandDto Model { get; set; }
    }
}
