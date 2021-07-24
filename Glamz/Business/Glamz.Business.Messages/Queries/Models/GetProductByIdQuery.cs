using Glamz.Domain.Catalog;
using MediatR;

namespace Glamz.Business.Messages.Queries.Models
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public string Id { get; set; }
    }
}
