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
            services.AddMvc();
            services.AddScoped<Glamz.Infrastructure.Caching.ICacheBase, Glamz.Infrastructure.Caching.MemoryCacheBase>();
            services.AddScoped<Glamz.Business.Common.Interfaces.Localization.ITranslationService, Glamz.Business.Common.Services.Localization.TranslationService>();
            services.AddScoped<Glamz.Business.Common.Interfaces.Localization.ILanguageService, Glamz.Business.Common.Services.Localization.LanguageService>();
            Glamz.Infrastructure.StartupBase.ConfigureServices(services, Configuration);
            //services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            //app.UseMvc();
            Glamz.Infrastructure.StartupBase.ConfigureRequestPipeline(app, env);
            DbEdmInitialization.DbInitiate(app, Configuration);
            //configure authentication
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
