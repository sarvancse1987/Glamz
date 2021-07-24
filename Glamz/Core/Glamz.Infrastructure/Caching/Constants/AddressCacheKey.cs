namespace Glamz.Infrastructure.Caching.Constants
{
    public static partial class CacheKey
    {
        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : address ID
        /// </remarks>
        public static string ADDRESSES_BY_ID_KEY => "Glamz.address.id-{0}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string ADDRESSES_PATTERN_KEY => "Glamz.address.";

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string ADDRESSATTRIBUTES_ALL_KEY => "Glamz.addressattribute.all";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : address attribute ID
        /// </remarks>
        public static string ADDRESSATTRIBUTES_BY_ID_KEY => "Glamz.addressattribute.id-{0}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string ADDRESSATTRIBUTES_PATTERN_KEY => "Glamz.addressattribute.";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string ADDRESSATTRIBUTEVALUES_PATTERN_KEY => "Glamz.addressattributevalue.";

    }
}
