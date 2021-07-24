using Glamz.Domain.Customers;
using Glamz.Domain.Stores;

namespace Glamz.Business.Catalog.Utilities
{
    /// <summary>
    /// Represents a discount requirement validation request
    /// </summary>
    public partial class DiscountRuleValidationRequest
    {
        /// <summary>
        /// Gets or sets the appropriate discount requirement ID (identifier)
        /// </summary>
        public string DiscountRequirementId { get; set; }

        /// <summary>
        /// Gets or sets the discount ID (identifier)
        /// </summary>
        public string DiscountId { get; set; }

        /// <summary>
        /// Gets or sets the customer
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the store
        /// </summary>
        public Store Store { get; set; }
    }
}
