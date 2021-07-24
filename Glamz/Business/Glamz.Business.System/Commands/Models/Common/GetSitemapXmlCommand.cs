using Glamz.Domain.Localization;
using Glamz.Domain.Stores;
using MediatR;

namespace Glamz.Business.System.Commands.Models.Common
{
    public class GetSitemapXmlCommand : IRequest<string>
    {
        public Store Store { get; set; }
        public Language Language { get; set; }
    }
}
