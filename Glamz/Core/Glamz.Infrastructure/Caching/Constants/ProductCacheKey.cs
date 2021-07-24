﻿namespace Glamz.Infrastructure.Caching.Constants
{
    public static partial class CacheKey
    {
        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string PRODUCTS_PATTERN_KEY => "Glamz.product.";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : product ID
        /// </remarks>
        public static string PRODUCTS_BY_ID_KEY => "Glamz.product.id-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : customer group IDs
        /// {1} : store ident
        /// </remarks>
        public static string PRODUCTS_CUSTOMER_GROUP => "Glamz.product.cr-{0}-{1}";

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string PRODUCTS_CUSTOMER_GROUP_PATTERN => "Glamz.product.cr";

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string PRODUCTS_HOMEPAGE_PATTERN => "Glamz.product.homepage";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : customer ID
        /// </remarks>
        public static string PRODUCTS_CUSTOMER_TAG => "Glamz.product.ct-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string PRODUCTS_CUSTOMER_TAG_PATTERN => "Glamz.product.ct";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : customer tag Id?
        /// </remarks>
        public static string CUSTOMERTAGPRODUCTS_ROLE_KEY => "Glamz.customertagproducts.tag-{0}";

        /// <summary>
        /// Key pattern to clear cache
        /// {0} customer id
        /// </summary>
        public static string PRODUCTS_CUSTOMER_PERSONAL_KEY => "Glamz.product.personal-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        public static string PRODUCTS_CUSTOMER_PERSONAL_PATTERN => "Glamz.product.personal";

        /// <summary>
        /// Key for cache 
        /// {0} - customer id
        /// {1} - product id
        /// </summary>
        public static string CUSTOMER_PRODUCT_PRICE_KEY_ID => "Glamz.product.price-{0}-{1}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string PRODUCTS_SHOWONHOMEPAGE => "Glamz.product.showonhomepage";

        /// <summary>
        /// Compare products cookie name
        /// </summary>
        public static string PRODUCTS_COMPARE_COOKIE_NAME => "Glamz.CompareProducts";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : store ID
        /// </remarks>
        public static string PRODUCTTAG_COUNT_KEY => "Glamz.producttag.count-{0}";

        /// <summary>
        /// Key for all tags
        /// </summary>
        public static string PRODUCTTAG_ALL_KEY => "Glamz.producttag.all";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string PRODUCTTAG_PATTERN_KEY => "Glamz.producttag.";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : customer id
        /// {1} : number
        /// </remarks>
        public static string RECENTLY_VIEW_PRODUCTS_KEY => "Glamz.recentlyviewedproducts-{0}-{1}";

        /// <summary>
        /// Key pattern to clear cache
        /// {0} customer id
        /// </summary>
        public static string RECENTLY_VIEW_PRODUCTS_PATTERN_KEY => "Glamz.recentlyviewedproducts-{0}";
    }
}
