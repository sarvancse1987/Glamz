using Glamz.Domain.Catalog;
using MediatR;

namespace Glamz.Business.Catalog.Queries.Models
{
    public class GetProductArchByIdQuery : IRequest<Product>
    {
        public string Id { get; set; }
    }
}
