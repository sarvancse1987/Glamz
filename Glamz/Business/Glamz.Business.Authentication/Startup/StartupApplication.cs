using FluentValidation;
using Glamz.Business.Authentication.Interfaces;
using Glamz.Business.Authentication.Services;
using Glamz.Business.Common;
using Glamz.Infrastructure;
using Glamz.Infrastructure.TypeSearchers;
using Glamz.Infrastructure.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Glamz.Business.Authentication.Startup
{
    public class StartupApplication : IStartupApplication
    {

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGrandAuthenticationService, CookieAuthenticationService>();
            services.AddScoped<IApiAuthenticationService, ApiAuthenticationService>();
            services.AddScoped<IJwtBearerAuthenticationService, JwtBearerAuthenticationService>();
            services.AddScoped<ITwoFactorAuthenticationService, TwoFactorAuthenticationService>();
            services.AddScoped<IExternalAuthenticationService, ExternalAuthenticationService>();
            services.AddScoped<IJwtBearerCustomerAuthenticationService, JwtBearerCustomerAuthenticationService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();


            RegisterContextService(services);
            RegisterValidators(services);
        }
        public void Configure(IApplicationBuilder application, IWebHostEnvironment webHostEnvironment)
        {

        }
        public int Priority => 100;
        public bool BeforeConfigure => false;


        private void RegisterContextService(IServiceCollection serviceCollection)
        {
            //work context
            serviceCollection.AddScoped<IWorkContext, WorkContext>();

            //helper for Settings
            serviceCollection.AddScoped<IStoreHelper, StoreHelper>();
        }

        private void RegisterValidators(IServiceCollection serviceCollection)
        {
            var typeSearcher = new AppTypeSearcher();

            var validators = typeSearcher.ClassesOfType(typeof(IValidator)).ToList();
            foreach (var validator in validators)
            {
                serviceCollection.AddTransient(validator);
            }

            //validator consumers
            var validatorconsumers = typeSearcher.ClassesOfType(typeof(IValidatorConsumer<>)).ToList();
            foreach (var consumer in validatorconsumers)
            {
                var types = consumer.GetTypeInfo().FindInterfaces((type, criteria) =>
                {
                    var isMatch = type.GetTypeInfo().IsGenericType && ((Type)criteria).IsAssignableFrom(type.GetGenericTypeDefinition());
                    return isMatch;
                }, typeof(IValidatorConsumer<>));
                foreach (var item in types)
                {
                    serviceCollection.AddScoped(item, consumer);
                }

            }
        }
    }
}
