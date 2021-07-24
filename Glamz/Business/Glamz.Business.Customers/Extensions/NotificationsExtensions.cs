using Glamz.Business.Customers.Events;
using Glamz.Business.Customers.Utilities;
using MediatR;
using System.Threading.Tasks;

namespace Glamz.Business.Customers.Extensions
{
    public static class EventsExtensions
    {
        public static async Task CustomerRegistrationEvent<C, R>(this IMediator eventPublisher, C result, R request) 
            where C : RegistrationResult where R : RegistrationRequest
        {
            await eventPublisher.Publish(new CustomerRegistrationEvent<C, R>(result, request));
        }
    }
}
