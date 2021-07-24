using Glamz.Domain.Customers;
using Glamz.Domain.Stores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glamz.Business.Common.Interfaces.Directory
{
    public interface ICookiePreference
    {
        IList<IConsentCookie> GetConsentCookies();
        Task<bool?> IsEnable(Customer customer, Store store, string cookieSystemName);
    }
}
