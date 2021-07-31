using Glamz.Business.Common.Interfaces.Localization;
using Glamz.Business.System.Interfaces.Installation;
using Glamz.SharedKernel.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Glamz.Business.System.Services.Installation
{
    public partial class InstallationService : IInstallationService
    {
        protected virtual async Task InstallLocaleResources()
        {
            try
            {


                //'English' language
                var language = _languageRepository.Table.Single(l => l.Name == "English");

                //save resources
                var filePath = CommonPath.MapPath("Rubix_Data/Resources/DefaultLanguage.xml");
                var localesXml = File.ReadAllText(filePath);
                var translationService = _serviceProvider.GetRequiredService<ITranslationService>();
                await translationService.ImportResourcesFromXmlInstall(language, localesXml);
            }
            catch (global::System.Exception ex)
            {

                throw;
            }
        }
    }
}
