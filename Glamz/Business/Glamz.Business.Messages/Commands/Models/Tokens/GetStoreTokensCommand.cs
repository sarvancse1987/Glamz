using Glamz.Domain.Localization;
using Glamz.Domain.Messages;
using Glamz.Domain.Stores;
using Glamz.Business.Messages.DotLiquidDrops;
using MediatR;

namespace Glamz.Business.Messages.Commands.Models
{
    public class GetStoreTokensCommand : IRequest<LiquidStore>
    {
        public Store Store { get; set; }
        public Language Language { get; set; }
        public EmailAccount EmailAccount { get; set; }
    }
}
