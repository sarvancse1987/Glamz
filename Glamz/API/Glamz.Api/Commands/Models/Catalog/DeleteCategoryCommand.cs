using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public CategoryDto Model { get; set; }
    }
}
