using Glamz.Domain.Catalog;
using MediatR;

namespace Glamz.Business.Catalog.Commands.Models
{
    public class UpdateProductReviewTotalsCommand : IRequest<bool>
    {
        public Product Product { get; set; }
    }
}
