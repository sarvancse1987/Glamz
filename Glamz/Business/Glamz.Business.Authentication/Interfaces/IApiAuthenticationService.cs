using Glamz.Domain.Customers;
using System.Threading.Tasks;

namespace Glamz.Business.Authentication.Interfaces
{
    public partial interface IApiAuthenticationService
    {
        /// <summary>
        /// Get authenticated customer
        /// </summary>
        /// <returns>Customer</returns>
        Task<Customer> GetAuthenticatedCustomer();
    }
}
