namespace Glamz.Infrastructure.Caching.Constants
{
    public static partial class CacheKey
    {
        #region Delivery date

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : delivery date ID
        /// </remarks>
        public static string DELIVERYDATE_BY_ID_KEY => "Glamz.deliverydate.id-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// </remarks>
        public static string DELIVERYDATE_ALL => "Glamz.deliverydate.all";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// </remarks>
        public static string DELIVERYDATE_PATTERN_KEY => "Glamz.deliverydate.";

        #endregion

        #region Pickup points

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : picpup point ID
        /// </remarks>
        public static string PICKUPPOINTS_BY_ID_KEY => "Glamz.pickuppoint.id-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string PICKUPPOINTS_ALL => "Glamz.pickuppoint.all";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string PICKUPPOINTS_PATTERN_KEY => "Glamz.pickuppoint.";

        #endregion

        #region Shipping method

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : shippingmethod ID
        /// </remarks>
        public static string SHIPPINGMETHOD_BY_ID_KEY => "Glamz.shippingmethod.id-{0}";

        /// <summary>
        /// Key to cache
        /// </summary>
        public static string SHIPPINGMETHOD_ALL => "Glamz.shippingmethod.all";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string SHIPPINGMETHOD_PATTERN_KEY => "Glamz.shippingmethod.";

        #endregion

        #region Warehouse

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : warehouse ID
        /// </remarks>
        public static string WAREHOUSES_BY_ID_KEY => "Glamz.warehouse.id-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string WAREHOUSES_ALL => "Glamz.warehouse.all";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string WAREHOUSES_PATTERN_KEY => "Glamz.warehouse.";

        #endregion
    }
}
