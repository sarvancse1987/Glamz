namespace Glamz.Infrastructure.Caching.Constants
{
    public static partial class CacheKey
    {
        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : page index
        /// {1} : page size
        /// </remarks>
        public static string PRODUCTATTRIBUTES_ALL_KEY => "Glamz.productattribute.all-{0}-{1}";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : product attribute ID
        /// </remarks>
        public static string PRODUCTATTRIBUTES_BY_ID_KEY => "Glamz.productattribute.id-{0}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string PRODUCTATTRIBUTES_PATTERN_KEY => "Glamz.productattribute.";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string PRODUCTATTRIBUTEMAPPINGS_PATTERN_KEY => "Glamz.productattributemapping.";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string PRODUCTATTRIBUTEVALUES_PATTERN_KEY => "Glamz.productattributevalue.";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string PRODUCTATTRIBUTECOMBINATIONS_PATTERN_KEY => "Glamz.productattributecombination.";

    }
}
