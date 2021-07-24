using Glamz.Domain.Customers;
using MediatR;

namespace Glamz.Business.Marketing.Events
{
    /// <summary>
    /// Customer coordinates save - event
    /// </summary>
    public class CustomerCoordinatesEvent : INotification
    {
        public CustomerCoordinatesEvent(Customer customer)
        {
            Customer = customer;
        }

        /// <summary>
        /// Customer
        /// </summary>
        public Customer Customer {
            get; private set;
        }

    }
}
