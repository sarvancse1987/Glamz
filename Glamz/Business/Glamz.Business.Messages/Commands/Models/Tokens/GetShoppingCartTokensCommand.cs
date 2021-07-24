using Glamz.Business.Messages.DotLiquidDrops;
using Glamz.Domain.Customers;
using Glamz.Domain.Localization;
using Glamz.Domain.Stores;
using MediatR;

namespace Glamz.Business.Messages.Commands.Models
{
    public class GetShoppingCartTokensCommand : IRequest<LiquidShoppingCart>
    {
        public Customer Customer { get; set; }
        public Store Store { get; set; }
        public Language Language { get; set; }
    }
}
