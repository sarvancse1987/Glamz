using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class UpdateCollectionCommand : IRequest<CollectionDto>
    {
        public CollectionDto Model { get; set; }
    }
}
