namespace Glamz.Infrastructure.Caching.Constants
{
    public static partial class CacheKey
    {
        #region page layout

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : warehouse ID
        /// </remarks>
        public static string PAGE_LAYOUT_BY_ID_KEY => "Glamz.page.layout.id-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string PAGE_LAYOUT_ALL => "Glamz.page.layout.all";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string PAGE_LAYOUT_PATTERN_KEY => "Glamz.page.layout.";

        #endregion

        #region product layout

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : layout ID
        /// </remarks>
        public static string PRODUCT_LAYOUT_BY_ID_KEY => "Glamz.product.layout.id-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string PRODUCT_LAYOUT_ALL => "Glamz.product.layout.all";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string PRODUCT_LAYOUT_PATTERN_KEY => "Glamz.product.layout.";

        #endregion

        #region category layout
        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : layout ID
        /// </remarks>
        public static string CATEGORY_LAYOUT_BY_ID_KEY => "Glamz.category.layout.id-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string CATEGORY_LAYOUT_ALL => "Glamz.category.layout.all";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string CATEGORY_LAYOUT_PATTERN_KEY => "Glamz.category.layout.";

        #endregion

        #region brand layout

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : layout ID
        /// </remarks>
        public static string BRAND_LAYOUT_BY_ID_KEY => "Glamz.brand.layout.id-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string BRAND_LAYOUT_ALL => "Glamz.brand.layout.all";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string BRAND_LAYOUT_PATTERN_KEY => "Glamz.brand.layout.";

        #endregion

        #region collection layout

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : layout ID
        /// </remarks>
        public static string COLLECTION_LAYOUT_BY_ID_KEY => "Glamz.collection.layout.id-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string COLLECTION_LAYOUT_ALL => "Glamz.collection.layout.all";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string COLLECTION_LAYOUT_PATTERN_KEY => "Glamz.collection.layout.";

        #endregion

    }
}
