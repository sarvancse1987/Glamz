using Glamz.Business.System.Interfaces.Installation;
using Glamz.Domain.Orders;
using System.Threading.Tasks;

namespace Glamz.Business.System.Services.Installation
{
    public partial class InstallationService : IInstallationService
    {
        protected virtual async Task InstallOrderTags()
        {
            var coolTag = new OrderTag
            {
                Name = "cool",
                Count = 0

            };
            await _orderTagRepository.InsertAsync(coolTag);

            var newTag = new OrderTag
            {
                Name = "new",
                Count = 0

            };
            await _orderTagRepository.InsertAsync(newTag);

            var oldTag = new OrderTag
            {
                Name = "old",
                Count = 0

            };
            await _orderTagRepository.InsertAsync(oldTag);

        }
    }
}
