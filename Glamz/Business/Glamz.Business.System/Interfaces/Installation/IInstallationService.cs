using System.Threading.Tasks;

namespace Glamz.Business.System.Interfaces.Installation
{
    public partial interface IInstallationService
    {
        Task InstallData(string defaultUserEmail, string defaultUserPassword, string collation, bool installSampleData = true, string companyName = "", string companyAddress = "", string companyPhoneNumber = "", string companyEmail = "");
    }
}
