using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class AddSpecificationAttributeCommand : IRequest<SpecificationAttributeDto>
    {
        public SpecificationAttributeDto Model { get; set; }
    }
}
