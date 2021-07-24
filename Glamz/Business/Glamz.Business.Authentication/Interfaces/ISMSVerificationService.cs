using Glamz.Business.Authentication.Utilities;
using Glamz.Domain.Customers;
using Glamz.Domain.Localization;
using System.Threading.Tasks;

namespace Glamz.Business.Authentication.Interfaces
{
    public interface ISMSVerificationService
    {
        Task<bool> Authenticate(string secretKey, string token, Customer customer);
        Task<TwoFactorCodeSetup> GenerateCode(string secretKey, Customer customer, Language language);
    }
}
