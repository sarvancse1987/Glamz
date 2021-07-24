using Glamz.Business.Marketing.Interfaces.Customers;
using Glamz.Business.System.Interfaces.ScheduleTasks;
using System.Threading.Tasks;

namespace Glamz.Business.System.Services.BackgroundServices.ScheduleTasks
{
    public partial class CustomerReminderLastActivityScheduleTask : IScheduleTask
    {
        private readonly ICustomerReminderService _customerReminderService;
        public CustomerReminderLastActivityScheduleTask(ICustomerReminderService customerReminderService)
        {
            _customerReminderService = customerReminderService;
        }

        public async Task Execute()
        {
            await _customerReminderService.Task_LastActivity();
        }
    }
}
