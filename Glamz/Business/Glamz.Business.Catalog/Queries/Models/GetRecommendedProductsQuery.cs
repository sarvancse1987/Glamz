using Glamz.Domain.Catalog;
using MediatR;
using System.Collections.Generic;

namespace Glamz.Business.Catalog.Queries.Models
{
    public class GetRecommendedProductsQuery : IRequest<IList<Product>>
    {
        public string[] CustomerGroupIds { get; set; }
        public string StoreId { get; set; }
    }
}
