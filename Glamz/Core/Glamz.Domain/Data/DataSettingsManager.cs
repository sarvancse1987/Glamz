using Glamz.SharedKernel.Extensions;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Glamz.Domain.Data
{
    /// <summary>
    /// Manager of data settings (connection string)
    /// </summary>
    public static class DataSettingsManager
    {

        private static DataSettings _dataSettings;

        private static bool? _databaseIsInstalled;

        /// <summary>
        /// Load settings
        /// </summary>
        public static DataSettings LoadSettings(bool reloadSettings = false,string connectionstring="")
        {
            //if (!reloadSettings && _dataSettings != null)
            //    return _dataSettings;

            //if (!File.Exists(CommonPath.SettingsPath))
            //    return new DataSettings();

            //try
            //{
            //    var text = File.ReadAllText(CommonPath.SettingsPath);
            //    _dataSettings = JsonSerializer.Deserialize<DataSettings>(text);
            //}
            //catch
            //{
            //    //Try to read file
            //    var connectionString = File.ReadLines(CommonPath.SettingsPath).FirstOrDefault();
            //    _dataSettings = new DataSettings() { ConnectionString = connectionString, DbProvider = DbProvider.MongoDB };

            //}
            //return _dataSettings;
            _dataSettings = new DataSettings();
            _dataSettings.ConnectionString = "mongodb://127.0.0.1:27017/GalmzApi";//connectionstring;
            _dataSettings.DbProvider = Glamz.Domain.Data.DbProvider.MongoDB;
            return _dataSettings;
        }

        /// <summary>
        /// Returns a value indicating whether database is already installed
        /// </summary>
        /// <returns></returns>
        public static bool DatabaseIsInstalled()
        {
            if (!_databaseIsInstalled.HasValue)
            {
                var settings = _dataSettings ?? LoadSettings();
                _databaseIsInstalled = settings != null && !string.IsNullOrEmpty(settings.ConnectionString);
            }
            return _databaseIsInstalled.Value;
        }

        public static void ResetCache()
        {
            _databaseIsInstalled = false;
        }

        /// <summary>
        /// Save settings to a file
        /// </summary>
        /// <param name="settings"></param>
        public static async Task SaveSettings(DataSettings settings)
        {
            var filePath = CommonPath.SettingsPath;
            if (!File.Exists(filePath))
            {
                using FileStream fs = File.Create(filePath);
            }
            var data = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(filePath, data);
        }
    }
}
