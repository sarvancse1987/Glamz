using Glamz.Business.Marketing.Interfaces.Banners;
using Glamz.Business.Marketing.Interfaces.Campaigns;
using Glamz.Business.Marketing.Interfaces.Contacts;
using Glamz.Business.Marketing.Interfaces.Courses;
using Glamz.Business.Marketing.Interfaces.Customers;
using Glamz.Business.Marketing.Interfaces.Documents;
using Glamz.Business.Marketing.Interfaces.Knowledgebase;
using Glamz.Business.Marketing.Interfaces.Newsletters;
using Glamz.Business.Marketing.Interfaces.PushNotifications;
using Glamz.Business.Marketing.Services.Banners;
using Glamz.Business.Marketing.Services.Campaigns;
using Glamz.Business.Marketing.Services.Contacts;
using Glamz.Business.Marketing.Services.Courses;
using Glamz.Business.Marketing.Services.Customers;
using Glamz.Business.Marketing.Services.Documents;
using Glamz.Business.Marketing.Services.Knowledgebase;
using Glamz.Business.Marketing.Services.Newsteletters;
using Glamz.Business.Marketing.Services.PushNotifications;
using Glamz.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Glamz.Business.Marketing.Startup
{
    public class StartupApplication : IStartupApplication
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            RegisterCoursesService(services);
            RegisterDocumentsService(services);
            RegisterKnowledgebaseService(services);
            RegisterCommon(services);
            RegisterCustomer(services);
        }
        public void Configure(IApplicationBuilder application, IWebHostEnvironment webHostEnvironment)
        {

        }
        public int Priority => 100;
        public bool BeforeConfigure => false;

        private void RegisterCustomer(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICustomerTagService, CustomerTagService>();
            serviceCollection.AddScoped<ICustomerActionService, CustomerActionService>();
            serviceCollection.AddScoped<ICustomerActionEventService, CustomerActionEventService>();
            serviceCollection.AddScoped<ICustomerReminderService, CustomerReminderService>();
            serviceCollection.AddScoped<ICustomerProductService, CustomerProductService>();
            serviceCollection.AddScoped<ICustomerCoordinatesService, CustomerCoordinatesService>();
        }
        private void RegisterCommon(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBannerService, BannerService>();
            serviceCollection.AddScoped<IPopupService, PopupService>();
            serviceCollection.AddScoped<IInteractiveFormService, InteractiveFormService>();
            serviceCollection.AddScoped<IPushNotificationsService, PushNotificationsService>();
            serviceCollection.AddScoped<IContactAttributeParser, ContactAttributeParser>();
            serviceCollection.AddScoped<IContactAttributeService, ContactAttributeService>();
            serviceCollection.AddScoped<IContactUsService, ContactUsService>();
            serviceCollection.AddScoped<INewsLetterSubscriptionService, NewsLetterSubscriptionService>();
            serviceCollection.AddScoped<INewsletterCategoryService, NewsletterCategoryService>();
            serviceCollection.AddScoped<ICampaignService, CampaignService>();
        }
        private void RegisterCoursesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICourseActionService, CourseActionService>();
            serviceCollection.AddScoped<ICourseLessonService, CourseLessonService>();
            serviceCollection.AddScoped<ICourseLevelService, CourseLevelService>();
            serviceCollection.AddScoped<ICourseService, CourseService>();
            serviceCollection.AddScoped<ICourseSubjectService, CourseSubjectService>();
        }
        private void RegisterDocumentsService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDocumentTypeService, DocumentTypeService>();
            serviceCollection.AddScoped<IDocumentService, DocumentService>();

        }
        private void RegisterKnowledgebaseService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IKnowledgebaseService, KnowledgebaseService>();
        }

    }
}
