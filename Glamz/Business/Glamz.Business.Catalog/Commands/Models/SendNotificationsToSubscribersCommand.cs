using Glamz.Domain.Catalog;
using Glamz.Domain.Common;
using MediatR;
using System.Collections.Generic;

namespace Glamz.Business.Catalog.Commands.Models
{
    public class SendNotificationsToSubscribersCommand : IRequest<IList<OutOfStockSubscription>>
    {
        public Product Product { get; set; }
        public IList<CustomAttribute> Attributes { get; set; }
        public string Warehouse { get; set; }
    }
}
