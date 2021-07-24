using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class UpdateCategoryCommand : IRequest<CategoryDto>
    {
        public CategoryDto Model { get; set; }
    }
}
