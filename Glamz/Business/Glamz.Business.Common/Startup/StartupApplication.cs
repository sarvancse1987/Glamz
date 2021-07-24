using Glamz.Business.Common.Interfaces.Addresses;
using Glamz.Business.Common.Interfaces.Configuration;
using Glamz.Business.Common.Interfaces.Directory;
using Glamz.Business.Common.Interfaces.Localization;
using Glamz.Business.Common.Interfaces.Logging;
using Glamz.Business.Common.Interfaces.Pdf;
using Glamz.Business.Common.Interfaces.Security;
using Glamz.Business.Common.Interfaces.Seo;
using Glamz.Business.Common.Interfaces.Stores;
using Glamz.Business.Common.Services.Addresses;
using Glamz.Business.Common.Services.Configuration;
using Glamz.Business.Common.Services.Directory;
using Glamz.Business.Common.Services.Localization;
using Glamz.Business.Common.Services.Logging;
using Glamz.Business.Common.Services.Pdf;
using Glamz.Business.Common.Services.Security;
using Glamz.Business.Common.Services.Seo;
using Glamz.Business.Common.Services.Stores;
using Glamz.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Glamz.Business.Common.Startup
{
    public class StartupApplication : IStartupApplication
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            RegisterCommonService(services);
            RegisterDirectoryService(services);
            RegisterConfigurationService(services);
            RegisterLocalizationService(services);
            RegisterLoggingService(services);
            RegisterSecurityService(services);
            RegisterSeoService(services);
            RegisterStoresService(services);


            //Newly Added
            var config = new Glamz.Infrastructure.Configuration.AppConfig();
            configuration.GetSection("Application").Bind(config);
            RegisterCache(services, config);
        }
        public void Configure(IApplicationBuilder application, IWebHostEnvironment webHostEnvironment)
        {

        }
        public int Priority => 100;
        public bool BeforeConfigure => false;

        private void RegisterCommonService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAddressAttributeParser, AddressAttributeParser>();
            serviceCollection.AddScoped<IAddressAttributeService, AddressAttributeService>();
            serviceCollection.AddScoped<IUserFieldService, UserFieldService>();
            serviceCollection.AddScoped<IHistoryService, HistoryService>();
            serviceCollection.AddScoped<IPdfService, WkPdfService>();
            serviceCollection.AddScoped<IViewRenderService, ViewRenderService>();

        }
        private void RegisterDirectoryService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISearchTermService, SearchTermService>();
            serviceCollection.AddScoped<IDateTimeService, DateTimeService>();
            serviceCollection.AddScoped<ICookiePreference, CookiePreference>();
            serviceCollection.AddScoped<IGeoLookupService, GeoLookupService>();
            serviceCollection.AddScoped<ICountryService, CountryService>();
            serviceCollection.AddScoped<ICurrencyService, CurrencyService>();
            serviceCollection.AddScoped<IExchangeRateService, ExchangeRateService>();
            serviceCollection.AddScoped<IMeasureService, MeasureService>();
            serviceCollection.AddScoped<IGroupService, GroupService>();
        }
        private void RegisterConfigurationService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISettingService, SettingService>();
            serviceCollection.AddScoped<IGoogleAnalyticsService, GoogleAnalyticsService>();
        }
        private void RegisterLocalizationService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITranslationService, TranslationService>();
            serviceCollection.AddScoped<ILanguageService, LanguageService>();
        }
        private void RegisterLoggingService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICustomerActivityService, CustomerActivityService>();
            serviceCollection.AddScoped<IActivityKeywordsProvider, ActivityKeywordsProvider>();
            serviceCollection.AddScoped<ILogger, DefaultLogger>();

        }
        private void RegisterSecurityService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPermissionService, PermissionService>();
            serviceCollection.AddScoped<IAclService, AclService>();
            serviceCollection.AddScoped<IEncryptionService, EncryptionService>();

        }

        private void RegisterSeoService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISlugService, SlugService>();
        }


        private void RegisterStoresService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStoreService, StoreService>();
        }



        //Newly Added
        private void RegisterCache(IServiceCollection serviceCollection, Infrastructure.Configuration.AppConfig config)
        {
            serviceCollection.AddSingleton<Glamz.Infrastructure.Caching.ICacheBase, Glamz.Infrastructure.Caching.MemoryCacheBase>();

            if (config.RedisPubSubEnabled)
            {
                var redis = ConnectionMultiplexer.Connect(config.RedisPubSubConnectionString);
                serviceCollection.AddSingleton<ISubscriber>(c => redis.GetSubscriber());
                serviceCollection.AddSingleton<Glamz.Infrastructure.Caching.Message.IMessageBus, Glamz.Infrastructure.Caching.Redis.RedisMessageBus>();
                serviceCollection.AddSingleton<Glamz.Infrastructure.Caching.ICacheBase, Glamz.Infrastructure.Caching.Redis.RedisMessageCacheManager>();
                return;
            }
            if (config.RabbitCachePubSubEnabled && config.RabbitEnabled)
            {
                serviceCollection.AddSingleton<Glamz.Infrastructure.Caching.ICacheBase, Glamz.Infrastructure.Caching.RabbitMq.RabbitMqMessageCacheManager>();
            }
        }

    }
}
