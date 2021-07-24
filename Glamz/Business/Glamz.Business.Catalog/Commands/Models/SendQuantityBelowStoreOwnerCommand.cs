using Glamz.Domain.Catalog;
using MediatR;

namespace Glamz.Business.Catalog.Commands.Models
{
    public class SendQuantityBelowStoreOwnerCommand : IRequest<bool>
    {
        public Product Product { get; set; }
        public ProductAttributeCombination ProductAttributeCombination { get; set; }

    }
}
