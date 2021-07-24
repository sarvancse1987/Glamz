﻿using Glamz.Api.Constants;
using Glamz.Business.Authentication.Interfaces;
using Glamz.Business.Authentication.Services;
using Glamz.Infrastructure;
using Glamz.Infrastructure.Configuration;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Glamz.Api.Infrastructure
{
    public partial class AuthenticationStartup : IStartupApplication
    {
        public void Configure(IApplicationBuilder application, IWebHostEnvironment webHostEnvironment)
        {
            var apiConfig = application.ApplicationServices.GetService<ApiConfig>();
            if (apiConfig.Enabled)
            {
                application.UseCors(Configurations.CorsPolicyName);
            }
        }

        public void ConfigureServices(IServiceCollection services,
            IConfiguration configuration)
        {
            var apiConfig = services.BuildServiceProvider().GetService<ApiConfig>();
            if (apiConfig.Enabled)
            {
                //cors
                services.AddCors(options =>
                {
                    options.AddPolicy(Configurations.CorsPolicyName,
                        builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
                });

                //Add OData
                services.AddOData();
                services.AddODataQueryFilter();
            }
        }
        public int Priority => 505;
        public bool BeforeConfigure => true;
    }
}
