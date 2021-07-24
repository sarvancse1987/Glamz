using Glamz.Business.System.Interfaces.ScheduleTasks;
using Glamz.Infrastructure.Caching;
using System.Threading.Tasks;

namespace Glamz.Business.System.Services.BackgroundServices.ScheduleTasks
{
    /// <summary>
    /// Clear cache schedueled task implementation
    /// </summary>
    public partial class ClearCacheScheduleTask : IScheduleTask
    {
        private readonly ICacheBase _cacheBase;

        public ClearCacheScheduleTask(ICacheBase cacheBase)
        {
            _cacheBase = cacheBase;
        }

        /// <summary>
        /// Executes a task
        /// </summary>
        public async Task Execute()
        {
            await _cacheBase.Clear();
        }
    }
}
