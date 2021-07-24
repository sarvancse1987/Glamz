using Glamz.Business.Authentication.Utilities;
using Glamz.Domain.Customers;
using Glamz.Domain.Localization;
using System.Threading.Tasks;

namespace Glamz.Business.Authentication.Interfaces
{
    public interface ITwoFactorAuthenticationService
    {
        Task<bool> AuthenticateTwoFactor(string secretKey, string token, Customer customer, TwoFactorAuthenticationType twoFactorAuthenticationType);

        Task<TwoFactorCodeSetup> GenerateCodeSetup(string secretKey, Customer customer, Language language, TwoFactorAuthenticationType twoFactorAuthenticationType);
        
    }
}
