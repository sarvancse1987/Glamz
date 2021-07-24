using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class DeleteSpecificationAttributeCommand : IRequest<bool>
    {
        public SpecificationAttributeDto Model { get; set; }
    }
}
