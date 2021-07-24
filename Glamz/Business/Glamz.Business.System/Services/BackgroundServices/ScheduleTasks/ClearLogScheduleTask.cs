using Glamz.Business.Common.Interfaces.Logging;
using Glamz.Business.System.Interfaces.ScheduleTasks;
using System.Threading.Tasks;

namespace Glamz.Business.System.Services.BackgroundServices.ScheduleTasks
{
    /// <summary>
    /// Represents a task to clear Log table
    /// </summary>
    public partial class ClearLogScheduleTask : IScheduleTask
    {
        private readonly ILogger _logger;
        public ClearLogScheduleTask(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Executes a task
        /// </summary>
        public async Task Execute()
        {
            await _logger.ClearLog();
        }
    }
}
