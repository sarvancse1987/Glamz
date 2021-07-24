using System;
using System.Collections.Generic;
using System.Text;

namespace Glamz.Infrastructure.Caching.Constants
{
    public static partial class CacheKey
    {
        #region Currency

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : currency ID
        /// </remarks>
        public static string CURRENCIES_BY_ID_KEY => "Glamz.currency.id-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : currency code
        /// </remarks>
        public static string CURRENCIES_BY_CODE => "Glamz.currency.code-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : show hidden records?
        /// </remarks>
        public static string CURRENCIES_ALL_KEY => "Glamz.currency.all-{0}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string CURRENCIES_PATTERN_KEY => "Glamz.currency.";

        #endregion

        #region Measure

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string MEASUREDIMENSIONS_ALL_KEY => "Glamz.measuredimension.all";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : dimension ID
        /// </remarks>
        public static string MEASUREDIMENSIONS_BY_ID_KEY => "Glamz.measuredimension.id-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string MEASUREWEIGHTS_ALL_KEY => "Glamz.measureweight.all";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : weight ID
        /// </remarks>
        public static string MEASUREWEIGHTS_BY_ID_KEY => "Glamz.measureweight.id-{0}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string MEASUREDIMENSIONS_PATTERN_KEY => "Glamz.measuredimension.";
        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string MEASUREWEIGHTS_PATTERN_KEY => "Glamz.measureweight.";

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string MEASUREUNITS_ALL_KEY => "Glamz.measureunit.all";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : dimension ID
        /// </remarks>
        public static string MEASUREUNITS_BY_ID_KEY => "Glamz.measureunit.id-{0}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string MEASUREUNITS_PATTERN_KEY => "Glamz.measureunit.";

        #endregion

        #region Country
        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// {1} : show hidden records?
        /// </remarks>
        public static string COUNTRIES_ALL_KEY => "Glamz.country.all-{0}-{1}";

        /// <summary>
        /// key for caching by country id
        /// </summary>
        /// <remarks>
        /// {0} : country ID
        /// </remarks>
        public static string COUNTRIES_BY_KEY => "Glamz.country.id-{0}";

        /// <summary>
        /// key for caching by country id
        /// </summary>
        /// <remarks>
        /// {0} : twoletter
        /// </remarks>
        public static string COUNTRIES_BY_TWOLETTER => "Glamz.country.twoletter-{0}";

        /// <summary>
        /// key for caching by country id
        /// </summary>
        /// <remarks>
        /// {0} : threeletter
        /// </remarks>
        public static string COUNTRIES_BY_THREELETTER => "Glamz.country.threeletter-{0}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string COUNTRIES_PATTERN_KEY => "Glamz.country.";

        #endregion

    }
}
