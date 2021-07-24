using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class AddCollectionCommand : IRequest<CollectionDto>
    {
        public CollectionDto Model { get; set; }
    }
}
