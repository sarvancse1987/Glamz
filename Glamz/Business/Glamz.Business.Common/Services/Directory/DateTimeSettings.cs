using Glamz.Domain.Configuration;

namespace Glamz.Business.Common.Interfaces.Directory
{
    public class DateTimeSettings : ISettings
    {
        /// <summary>
        /// Gets or sets a default store time zone ident
        /// </summary>
        public string DefaultStoreTimeZoneId { get; set; }

    }
}