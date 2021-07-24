using MediatR;

namespace Glamz.Business.Checkout.Commands.Models.Orders
{
    public class PrepareOrderCodeCommand : IRequest<string>
    {
    }
}
