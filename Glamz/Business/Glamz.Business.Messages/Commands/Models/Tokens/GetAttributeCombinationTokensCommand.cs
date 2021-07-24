using Glamz.Domain.Catalog;
using Glamz.Business.Messages.DotLiquidDrops;
using MediatR;

namespace Glamz.Business.Messages.Commands.Models
{
    public class GetAttributeCombinationTokensCommand : IRequest<LiquidAttributeCombination>
    {
        public Product Product { get; set; }
        public ProductAttributeCombination Combination { get; set; }
    }
}
