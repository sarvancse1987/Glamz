namespace Glamz.Infrastructure.Caching.Constants
{
    public static partial class CacheKey
    {
        public static string CUSTOMER_ACTION_TYPE => "Glamz.customer.action.type";

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string CUSTOMERATTRIBUTES_ALL_KEY => "Glamz.customerattribute.all";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : customer attribute ID
        /// </remarks>
        public static string CUSTOMERATTRIBUTES_BY_ID_KEY => "Glamz.customerattribute.id-{0}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string CUSTOMERATTRIBUTES_PATTERN_KEY => "Glamz.customerattribute.";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string CUSTOMERATTRIBUTEVALUES_PATTERN_KEY => "Glamz.customerattributevalue.";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : ident
        /// </remarks>
        public static string CUSTOMERGROUPS_BY_KEY => "Glamz.customergroup.key-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// </remarks>
        public static string CUSTOMERGROUPS_ALL => "Glamz.customergroup.all";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : system name
        /// </remarks>
        public static string CUSTOMERGROUPS_BY_SYSTEMNAME_KEY => "Glamz.customergroup.systemname-{0}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string CUSTOMERGROUPS_PATTERN_KEY => "Glamz.customergroup.";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : customer group Id?
        /// </remarks>
        public static string CUSTOMERGROUPSPRODUCTS_ROLE_KEY => "Glamz.customergroupproducts.role-{0}";

        #region Customer activity

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : ident
        /// </remarks>
        public static string ACTIVITYTYPE_BY_KEY => "Glamz.activitytype.id-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string ACTIVITYTYPE_ALL_KEY => "Glamz.activitytype.all";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string ACTIVITYTYPE_PATTERN_KEY => "Glamz.activitytype.";

        #endregion

        #region Sales person

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : salesemployee ID
        /// </remarks>
        public static string SALESEMPLOYEE_BY_ID_KEY => "Glamz.salesemployee.id-{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        public static string SALESEMPLOYEE_ALL => "Glamz.salesemployee.all";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        public static string SALESEMPLOYEE_PATTERN_KEY => "Glamz.salesemployee.";

        #endregion
    }
}
