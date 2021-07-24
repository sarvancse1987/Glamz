using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glamz.Api
{
    public static class DbEdmInitialization
    {
        public static async Task<bool> DbInitiate(this IApplicationBuilder app, IConfiguration configuration)
        {
            bool issuccess = false;
            try
            {
                string connectionString = string.Empty;

                if (Glamz.Domain.Data.DataSettingsManager.DatabaseIsInstalled())
                {
                    connectionString = "mongodb://127.0.0.1:27017/GalmzApi";
                }


                var mdb = new Glamz.Domain.Data.Mongo.MongoDBContext();
                mdb.DatabaseExist(connectionString);

                InstallModel model = new InstallModel()
                {
                    AdminEmail = "saravanan@rubixtek.com",
                    AdminPassword = "123456",
                    InstallSampleData = false,
                    CompanyName = "Rubitek",
                    CompanyAddress = "Trichy",
                    CompanyPhoneNumber = "1234567890",
                    CompanyEmail = "saravanan@rubixtek.com",
                    Collation="en"
                };

                #region Not Required
                //var settings = new Domain.Data.DataSettings
                //{
                //    ConnectionString = connectionString,
                //    DbProvider = model.DataProvider
                //};
                //Domain.Data.DataSettingsManager.SaveSettings(settings);
                #endregion

                var installationService = app.ApplicationServices.GetRequiredService<Glamz.Business.System.Interfaces.Installation.IInstallationService>();
                await installationService.InstallData(model.AdminEmail, model.AdminPassword, model.Collation,
                   model.InstallSampleData, model.CompanyName, model.CompanyAddress, model.CompanyPhoneNumber, model.CompanyEmail);

                //reset cache
                Domain.Data.DataSettingsManager.ResetCache();

                #region Not Required
                //PluginManager.ClearPlugins();

                //var pluginsInfo = PluginManager.ReferencedPlugins.ToList();

                //foreach (var pluginInfo in pluginsInfo)
                //{
                //    try
                //    {
                //        var plugin = pluginInfo.Instance<IPlugin>(_serviceProvider);
                //        await plugin.Install();
                //    }
                //    catch (Exception ex)
                //    {
                //        var _logger = _serviceProvider.GetRequiredService<ILogger>();
                //        await _logger.InsertLog(Domain.Logging.LogLevel.Error, "Error during installing plugin " + pluginInfo.SystemName,
                //            ex.Message + " " + ex.InnerException?.Message);
                //    }
                //}
                #endregion

                //register default permissions
                var permissionProviders = new List<Type>();
                permissionProviders.Add(typeof(Glamz.Business.Common.Services.Security.PermissionProvider));
                foreach (var providerType in permissionProviders)
                {
                    var provider = (Glamz.Business.Common.Interfaces.Security.IPermissionProvider)Activator.CreateInstance(providerType);
                    //var installationService = app.ApplicationServices.GetRequiredService<Glamz.Business.System.Interfaces.Installation.>();
                    //_mediator.Send(new Glamz.Business.System.Commands.Models.Security.InstallPermissionsCommand() { PermissionProvider = provider });
                }
            }
            catch (Exception ex)
            {

            }
            return issuccess;
        }
    }
}
