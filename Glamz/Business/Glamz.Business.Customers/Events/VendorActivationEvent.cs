using Glamz.Domain.Vendors;
using MediatR;

namespace Glamz.Business.Customers.Events
{
    public class VendorActivationEvent : INotification
    {
        public VendorActivationEvent(Vendor vendor)
        {
            Vendor = vendor;
        }

        /// <summary>
        /// Vendor
        /// </summary>
        public Vendor Vendor {
            get; private set;
        }
    }
}
