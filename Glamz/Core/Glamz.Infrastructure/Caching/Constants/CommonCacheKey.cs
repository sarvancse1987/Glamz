namespace Glamz.Infrastructure.Caching.Constants
{
    public static partial class CacheKey
    {
        #region Settings

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : key - settings name
        /// {1} : store ident
        /// </remarks>
        public static string SETTINGS_BY_KEY => "Glamz.setting.{0}.{1}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string SETTINGS_PATTERN_KEY => "Glamz.setting.";

        #endregion

        #region Discounts

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : discont ID
        /// </remarks>
        public static string DISCOUNTS_BY_ID_KEY => "Glamz.discount.id-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : show hidden records?
        /// {1} : store ident
        /// {2} : currency code
        /// {3} : coupon code
        /// {4} : discount name
        /// </remarks>
        public static string DISCOUNTS_ALL_KEY => "Glamz.discount.all-{0}-{1}-{2}-{3}-{4}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string DISCOUNTS_PATTERN_KEY => "Glamz.discount.";

        #endregion

        #region Languages & localization

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// </remarks>
        public static string LANGUAGES_BY_ID_KEY => "Glamz.language.id-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : show hidden records?
        /// </remarks>
        public static string LANGUAGES_ALL_KEY => "Glamz.language.all-{0}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string LANGUAGES_PATTERN_KEY => "Glamz.language.";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// </remarks>
        public static string TRANSLATERESOURCES_ALL_KEY => "Glamz.translate.all-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// {1} : resource key
        /// </remarks>
        public static string TRANSLATERESOURCES_BY_RESOURCENAME_KEY => "Glamz.translate.{0}-{1}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string TRANSLATERESOURCES_PATTERN_KEY => "Glamz.translate.";

        #endregion

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : picture ID
        /// </remarks>
        public static string PICTURE_BY_ID => "Glamz.picture-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : picture ID
        /// {1} : store ID
        /// {2} : target size
        /// {3} : showDefaultPicture
        /// {4} : storeLocation
        /// </remarks>
        public static string PICTURE_BY_KEY => "Glamz.picture-{0}-{1}-{2}-{3}-{4}";

        #region Seo

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : entity ID
        /// {1} : entity name
        /// {2} : language ID
        /// </remarks>
        public static string URLEntity_ACTIVE_BY_ID_NAME_LANGUAGE_KEY => "Glamz.urlEntity.active.id-name-language-{0}-{1}-{2}";

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string URLEntity_ALL_KEY => "Glamz.urlEntity.all";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : slug
        /// </remarks>
        public static string URLEntity_BY_SLUG_KEY => "Glamz.urlEntity.active.slug-{0}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string URLEntity_PATTERN_KEY = "Glamz.urlEntity.";

        #endregion

        #region Stores

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string STORES_ALL_KEY => "Glamz.stores.all";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : store ID
        /// </remarks>
        public static string STORES_BY_ID_KEY => "Glamz.stores.id-{0}";

        #endregion

        #region Tax

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string TAXCATEGORIES_ALL_KEY => "Glamz.taxcategory.all";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : tax category ID
        /// </remarks>
        public static string TAXCATEGORIES_BY_ID_KEY => "Glamz.taxcategory.id-{0}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string TAXCATEGORIES_PATTERN_KEY => "Glamz.taxcategory.";

        #endregion

        #region Pages

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : store ID
        /// {1} : ignore ACL?
        /// </remarks>
        public static string PAGES_ALL_KEY => "Glamz.pages.all-{0}-{1}";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : page ID
        /// </remarks>
        public static string PAGES_BY_ID_KEY => "Glamz.pages.id-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : page systemname
        /// {1} : store id
        /// </remarks>
        public static string PAGES_BY_SYSTEMNAME => "Glamz.pages.systemname-{0}-{1}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string PAGES_PATTERN_KEY => "Glamz.pages.";

        #endregion
    }
}
