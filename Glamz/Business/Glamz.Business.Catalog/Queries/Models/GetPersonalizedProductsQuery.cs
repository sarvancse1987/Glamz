using Glamz.Domain.Catalog;
using MediatR;
using System.Collections.Generic;

namespace Glamz.Business.Catalog.Queries.Models
{
    public class GetPersonalizedProductsQuery : IRequest<IList<Product>>
    {
        public string CustomerId { get; set; }
        public int ProductsNumber { get; set; }
    }
}
