using Glamz.Business.System.Interfaces.Installation;
using Glamz.Domain.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glamz.Business.System.Services.Installation
{
    public partial class InstallationService : IInstallationService
    {
        protected virtual async Task InstallPageLayouts()
        {
            var pageLayouts = new List<PageLayout>
                               {
                                   new PageLayout
                                       {
                                           Name = "Default layout",
                                           ViewPath = "PageDetails",
                                           DisplayOrder = 1
                                       },
                               };
            await _pageLayoutRepository.InsertAsync(pageLayouts);
        }
    }
}
