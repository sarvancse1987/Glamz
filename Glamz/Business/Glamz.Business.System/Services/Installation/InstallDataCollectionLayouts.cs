using Glamz.Business.System.Interfaces.Installation;
using Glamz.Domain.Catalog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glamz.Business.System.Services.Installation
{
    public partial class InstallationService : IInstallationService
    {
        protected virtual async Task InstallCollectionLayouts()
        {
            var collectionLayouts = new List<CollectionLayout>
                               {
                                   new CollectionLayout
                                       {
                                           Name = "Grid or Lines",
                                           ViewPath = "CollectionLayout.GridOrLines",
                                           DisplayOrder = 1
                                       },
                               };
            await _collectionLayoutRepository.InsertAsync(collectionLayouts);
        }
    }
}
