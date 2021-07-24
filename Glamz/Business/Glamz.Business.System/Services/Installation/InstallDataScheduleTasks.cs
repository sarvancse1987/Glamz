using Glamz.Business.System.Interfaces.Installation;
using Glamz.Domain.Directory;
using Glamz.Domain.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glamz.Business.System.Services.Installation
{
    public partial class InstallationService : IInstallationService
    {
        protected virtual async Task InstallScheduleTasks()
        {
            //these tasks are default - they are created in order to insert them into database
            //and nothing above it
            //there is no need to send arguments into ctor - all are null
            var tasks = new List<ScheduleTask>
            {
            new ScheduleTask
            {
                    ScheduleTaskName = "Send emails",
                    Type = "Glamz.Business.System.Services.BackgroundServices.ScheduleTasks.QueuedMessagesSendScheduleTask, Glamz.Business.System",
                    Enabled = true,
                    StopOnError = false,
                    TimeInterval = 1
                },
                new ScheduleTask
                {
                    ScheduleTaskName = "Delete guests",
                    Type = "Glamz.Business.System.Services.BackgroundServices.ScheduleTasks.DeleteGuestsScheduleTask, Glamz.Business.System",
                    Enabled = true,
                    StopOnError = false,
                    TimeInterval = 1440
                },
                new ScheduleTask
                {
                    ScheduleTaskName = "Clear cache",
                    Type = "Glamz.Business.System.Services.BackgroundServices.ScheduleTasks.ClearCacheScheduleTask, Glamz.Business.System",
                    Enabled = false,
                    StopOnError = false,
                    TimeInterval = 120
                },
                new ScheduleTask
                {
                    ScheduleTaskName = "Clear log",
                    Type = "Glamz.Business.System.Services.BackgroundServices.ScheduleTasks.ClearLogScheduleTask, Glamz.Business.System",
                    Enabled = false,
                    StopOnError = false,
                    TimeInterval = 1440
                },
                new ScheduleTask
                {
                    ScheduleTaskName = "Update currency exchange rates",
                    Type = "Glamz.Business.System.Services.BackgroundServices.ScheduleTasks.UpdateExchangeRateScheduleTask, Glamz.Business.System",
                    Enabled = true,
                    StopOnError = false,
                    TimeInterval = 1440
                },
                new ScheduleTask
                {
                    ScheduleTaskName = "Generate sitemap XML file",
                    Type = "Glamz.Business.System.Services.BackgroundServices.ScheduleTasks.GenerateSitemapXmlTask, Glamz.Business.System",
                    Enabled = false,
                    StopOnError = false,
                    TimeInterval = 10080
                },
                new ScheduleTask
                {
                    ScheduleTaskName = "Customer reminder - AbandonedCart",
                    Type = "Glamz.Business.System.Services.BackgroundServices.ScheduleTasks.CustomerReminderAbandonedCartScheduleTask, Glamz.Business.System",
                    Enabled = false,
                    StopOnError = false,
                    TimeInterval = 20
                },
                new ScheduleTask
                {
                    ScheduleTaskName = "Customer reminder - RegisteredCustomer",
                    Type = "Glamz.Business.System.Services.BackgroundServices.ScheduleTasks.CustomerReminderRegisteredCustomerScheduleTask, Glamz.Business.System",
                    Enabled = false,
                    StopOnError = false,
                    TimeInterval = 1440
                },
                new ScheduleTask
                {
                    ScheduleTaskName = "Customer reminder - LastActivity",
                    Type = "Glamz.Business.System.Services.BackgroundServices.ScheduleTasks.CustomerReminderLastActivityScheduleTask, Glamz.Business.System",
                    Enabled = false,
                    StopOnError = false,
                    TimeInterval = 1440
                },
                new ScheduleTask
                {
                    ScheduleTaskName = "Customer reminder - LastPurchase",
                    Type = "Glamz.Business.System.Services.BackgroundServices.ScheduleTasks.CustomerReminderLastPurchaseScheduleTask, Glamz.Business.System",
                    Enabled = false,
                    StopOnError = false,
                    TimeInterval = 1440
                },
                new ScheduleTask
                {
                    ScheduleTaskName = "Customer reminder - Birthday",
                    Type = "Glamz.Business.System.Services.BackgroundServices.ScheduleTasks.CustomerReminderBirthdayScheduleTask, Glamz.Business.System",
                    Enabled = false,
                    StopOnError = false,
                    TimeInterval = 1440
                },
                new ScheduleTask
                {
                    ScheduleTaskName = "Customer reminder - Completed order",
                    Type = "Glamz.Business.System.Services.BackgroundServices.ScheduleTasks.CustomerReminderCompletedOrderScheduleTask, Glamz.Business.System",
                    Enabled = false,
                    StopOnError = false,
                    TimeInterval = 1440
                },
                new ScheduleTask
                {
                    ScheduleTaskName = "Customer reminder - Unpaid order",
                    Type = "Glamz.Business.System.Services.BackgroundServices.ScheduleTasks.CustomerReminderUnpaidOrderScheduleTask, Glamz.Business.System",
                    Enabled = false,
                    StopOnError = false,
                    TimeInterval = 1440
                },
                new ScheduleTask
                {
                    ScheduleTaskName = "End of the auctions",
                    Type = "Glamz.Business.System.Services.BackgroundServices.ScheduleTasks.EndAuctionsTask, Glamz.Business.System",
                    Enabled = false,
                    StopOnError = false,
                    TimeInterval = 60
                },
                new ScheduleTask
                {
                    ScheduleTaskName = "Cancel unpaid and pending orders",
                    Type = "Glamz.Business.System.Services.BackgroundServices.ScheduleTasks.CancelOrderScheduledTask, Glamz.Business.System",
                    Enabled = false,
                    StopOnError = false,
                    TimeInterval = 1440
                },
            };
            await _scheduleTaskRepository.InsertAsync(tasks);
        }
    }
}
