using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Glamz.Infrastructure.Configuration;
using Glamz.Business.Authentication.Utilities;
using Microsoft.AspNetCore.Http;
using Glamz.Infrastructure.TypeSearchers;
using Glamz.Business.Authentication.Interfaces;
using Glamz.Infrastructure.Plugins;
using Glamz.Domain.Data;
using Glamz.Api.Infrastructure;
using Glamz.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json.Serialization;
using Glamz.Domain.Data.Mongo;
using Glamz.Business.Authentication.Services;

namespace Glamz.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly IMediator _mediator;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                services.AddCors();

                services.AddControllers();
                services.AddHttpContextAccessor();

                services.AddMemoryCache();

                services.AddMvc(options =>
                {
                    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                    options.Filters.Add(new AuthorizeFilter(policy));

                    var jsonOutFormatter = options.OutputFormatters.OfType<SystemTextJsonOutputFormatter>().FirstOrDefault();
                    if (jsonOutFormatter != null)
                    {
                        //removing text/json as it is not approved media type for working with JSON
                        if (jsonOutFormatter.SupportedMediaTypes.Contains("text/json"))
                            jsonOutFormatter.SupportedMediaTypes.Remove("text/json");
                    }
                    options.Filters.Add(new ProducesAttribute("application/json"));
                })
           .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
           .AddJsonOptions(optios => optios.JsonSerializerOptions.IgnoreNullValues = false);

                services.Configure<ApiBehaviorOptions>(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });



                //services.AddMvc();
                services.AddScoped<Glamz.Infrastructure.Caching.ICacheBase, Glamz.Infrastructure.Caching.MemoryCacheBase>();
                //services.AddScoped<Glamz.Business.Common.Interfaces.Localization.ITranslationService, Glamz.Business.Common.Services.Localization.TranslationService>();
                services.AddScoped<Glamz.Business.Common.Interfaces.Localization.ILanguageService, Glamz.Business.Common.Services.Localization.LanguageService>();
                //services.AddTransient<IDatabaseContext, MongoDBContext>();
                services.AddScoped<IGrandAuthenticationService, CookieAuthenticationService>();
                services.AddTransient<WorkContextMiddleware>();
                Glamz.Infrastructure.StartupBase.ConfigureServices(services, Configuration);
              
                //services.AddControllers();

                var config = new AppConfig();
                Configuration.GetSection("Application").Bind(config);

                //set default authentication schemes
                var authenticationBuilder = services.AddAuthentication(options =>
                {
                    options.DefaultScheme = GrandCookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = GrandCookieAuthenticationDefaults.ExternalAuthenticationScheme;
                });

                //add main cookie authentication
                authenticationBuilder.AddCookie(GrandCookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.Cookie.Name = config.CookiePrefix + GrandCookieAuthenticationDefaults.AuthenticationScheme;
                    options.Cookie.HttpOnly = true;
                    options.LoginPath = GrandCookieAuthenticationDefaults.LoginPath;
                    options.AccessDeniedPath = GrandCookieAuthenticationDefaults.AccessDeniedPath;

                    options.Cookie.SecurePolicy = config.CookieSecurePolicyAlways ? CookieSecurePolicy.Always : CookieSecurePolicy.SameAsRequest;
                });

                //add external authentication
                authenticationBuilder.AddCookie(GrandCookieAuthenticationDefaults.ExternalAuthenticationScheme, options =>
                {
                    options.Cookie.Name = config.CookiePrefix + GrandCookieAuthenticationDefaults.ExternalAuthenticationScheme;
                    options.Cookie.HttpOnly = true;
                    options.LoginPath = GrandCookieAuthenticationDefaults.LoginPath;
                    options.AccessDeniedPath = GrandCookieAuthenticationDefaults.AccessDeniedPath;
                    options.Cookie.SecurePolicy = config.CookieSecurePolicyAlways ? CookieSecurePolicy.Always : CookieSecurePolicy.SameAsRequest;
                });

                //register external authentication plugins now
                var typeSearcher = new AppTypeSearcher();
                var externalAuthConfigurations = typeSearcher.ClassesOfType<IAuthenticationBuilder>();
                var externalAuthInstances = externalAuthConfigurations
                    .Where(x => PluginExtensions.OnlyInstalledPlugins(x))
                    .Select(x => (IAuthenticationBuilder)Activator.CreateInstance(x))
                    .OrderBy(x => x.Priority);

                //add new Authentication
                foreach (var instance in externalAuthInstances)
                    instance.AddAuthentication(authenticationBuilder, Configuration);

                var mvcBuilder = services.AddMvc(options =>
                {
                    //for API - ignore for PWA
                    options.Conventions.Add(new ApiExplorerIgnores());
                });

                //add view localization
                mvcBuilder.AddViewLocalization();
                //add razor runtime compilation
                mvcBuilder.AddRazorRuntimeCompilation();

                services.AddDetection();

                if (config.UseHsts)
                {
                    services.AddHsts(options =>
                    {
                        options.Preload = true;
                        options.IncludeSubDomains = true;
                    });
                }

                services.AddSession(options =>
                {
                    options.Cookie = new CookieBuilder()
                    {
                        Name = $"{config.CookiePrefix}Session",
                        HttpOnly = true,
                    };
                    if (DataSettingsManager.DatabaseIsInstalled())
                    {
                        options.Cookie.SecurePolicy = config.CookieSecurePolicyAlways ? CookieSecurePolicy.Always : CookieSecurePolicy.SameAsRequest;
                    }
                });

                if (config.UseHttpsRedirection)
                {
                    services.AddHttpsRedirection(options =>
                    {
                        options.RedirectStatusCode = config.HttpsRedirectionRedirect;
                        options.HttpsPort = config.HttpsRedirectionHttpsPort;
                    });
                }
                //use session-based temp data provider
                if (config.UseSessionStateTempDataProvider)
                {
                    mvcBuilder.AddSessionStateTempDataProvider();
                }

                //MVC now serializes JSON with camel case names by default, use this code to avoid it
                mvcBuilder.AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

                //register controllers as services, it'll allow to override them
                mvcBuilder.AddControllersAsServices();

                if (config.EnableProgressiveWebApp)
                {
                    var options = new WebEssentials.AspNetCore.Pwa.PwaOptions
                    {
                        Strategy = (WebEssentials.AspNetCore.Pwa.ServiceWorkerStrategy)config.ServiceWorkerStrategy,
                        RoutesToIgnore = "/admin/*"
                    };
                    services.AddProgressiveWebApp(options);
                }

                services.AddSingleton<IActionResultExecutor<RedirectResult>, GrandRedirectResultExecutor>();
                services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));
                
                services.AddRouting(Option => Option.LowercaseUrls = true);
                services.BuildServiceProvider();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var serviceProvider = app.ApplicationServices;
            var appConfig = serviceProvider.GetRequiredService<AppConfig>();
            if (appConfig.UseDefaultSecurityHeaders)
            {
                var policyCollection = new HeaderPolicyCollection()
                .AddXssProtectionBlock()
                .AddContentTypeOptionsNoSniff()
                .AddStrictTransportSecurityMaxAgeIncludeSubDomains(maxAgeInSeconds: 60 * 60 * 24 * 365) // maxage = one year in seconds
                .AddReferrerPolicyStrictOriginWhenCrossOrigin()
                .AddContentSecurityPolicy(builder =>
                {
                    builder.AddUpgradeInsecureRequests();
                    builder.AddDefaultSrc().Self();
                    builder.AddConnectSrc().From("*");
                    builder.AddFontSrc().From("*");
                    builder.AddFrameAncestors().From("*");
                    builder.AddFrameSrc().From("*");
                    builder.AddMediaSrc().From("*");
                    builder.AddImgSrc().From("*").Data();
                    builder.AddObjectSrc().From("*");
                    builder.AddScriptSrc().From("*").UnsafeInline().UnsafeEval();
                    builder.AddStyleSrc().From("*").UnsafeEval().UnsafeInline();
                })
                .RemoveServerHeader();

                app.UseSecurityHeaders(policyCollection);
            }

            if (appConfig.UseHsts)
            {
                app.UseHsts();
            }

            if (appConfig.UseHttpsRedirection)
            {
                app.UseHttpsRedirection();
            }

            //compression
            if (appConfig.UseResponseCompression)
            {
                //gzip by default
                app.UseResponseCompression();
            }

            if (appConfig.UseRequestLocalization)
            {
                var supportedCultures = new List<CultureInfo>();
                foreach (var culture in appConfig.SupportedCultures)
                {
                    supportedCultures.Add(new CultureInfo(culture));
                }
                app.UseRequestLocalization(new RequestLocalizationOptions
                {
                    DefaultRequestCulture = new RequestCulture(appConfig.DefaultRequestCulture),
                    SupportedCultures = supportedCultures,
                    SupportedUICultures = supportedCultures
                });
            }
            else
                //use default request localization
                app.UseRequestLocalization();

            app.UseSession();

            app.UseDetection();
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //set workcontext

            //app.UseMiddleware<DbVersionCheckMiddleware>();

            DbEdmInitialization.DbInitiate(app, Configuration);

            //configure authentication



            //check whether database is installed
            if (!DataSettingsManager.DatabaseIsInstalled())
                return;
            app.UseMiddleware<WorkContextMiddleware>();
            Glamz.Infrastructure.StartupBase.ConfigureRequestPipeline(app, env);
           


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            //app.UseMvc();
            try
            {
             
                //app.UseRouting();

                app.UseEndpoints(endpoints =>
                {
                    var typeSearcher = endpoints.ServiceProvider.GetRequiredService<ITypeSearcher>();
                    var endpointProviders = typeSearcher.ClassesOfType<IEndpointProvider>();
                    var instances = endpointProviders
                        .Where(endpointProvider => PluginExtensions.OnlyInstalledPlugins(endpointProvider))
                        .Select(endpointProvider => (IEndpointProvider)Activator.CreateInstance(endpointProvider))
                        .OrderByDescending(endpointProvider => endpointProvider.Priority);

                    foreach (var endpointProvider in instances)
                        endpointProvider.RegisterEndpoint(endpoints);
                });
              

               
                //configure authentication
                //app.UseAuthentication();
                //app.UseAuthorization();


            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
