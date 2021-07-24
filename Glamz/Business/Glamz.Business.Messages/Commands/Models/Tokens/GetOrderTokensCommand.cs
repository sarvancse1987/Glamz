using Glamz.Domain.Customers;
using Glamz.Domain.Orders;
using Glamz.Domain.Stores;
using Glamz.Domain.Vendors;
using Glamz.Business.Messages.DotLiquidDrops;
using MediatR;

namespace Glamz.Business.Messages.Commands.Models
{
    public class GetOrderTokensCommand : IRequest<LiquidOrder>
    {
        public Order Order { get; set; }
        public Customer Customer { get; set; }
        public Store Store { get; set; }
        public OrderNote OrderNote { get; set; } = null;
        public Vendor Vendor { get; set; } = null;
        public double RefundedAmount { get; set; } = 0;
    }
}
