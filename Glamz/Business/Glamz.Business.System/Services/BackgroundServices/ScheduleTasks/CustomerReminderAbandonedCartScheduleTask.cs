using Glamz.Business.Marketing.Interfaces.Customers;
using Glamz.Business.System.Interfaces.ScheduleTasks;
using System.Threading.Tasks;

namespace Glamz.Business.System.Services.BackgroundServices.ScheduleTasks
{
    public partial class CustomerReminderAbandonedCartScheduleTask : IScheduleTask
    {
        private readonly ICustomerReminderService _customerReminderService;

        public CustomerReminderAbandonedCartScheduleTask(ICustomerReminderService customerReminderService)
        {
            _customerReminderService = customerReminderService;
        }

        public async Task Execute()
        {
            await _customerReminderService.Task_AbandonedCart();
        }
    }
}
