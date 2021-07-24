using FluentValidation;
using Glamz.Infrastructure;
using Glamz.Infrastructure.TypeSearchers;
using Glamz.Infrastructure.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Glamz.Business.Common.External
{
    public class StartupApplication : IStartupApplication
    {
        public int Priority => 100;

        public bool BeforeConfigure => false;

        public void Configure(IApplicationBuilder application, IWebHostEnvironment webHostEnvironment)
        {
            
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            RegisterContextService(services);
            RegisterValidators(services);
        }

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
