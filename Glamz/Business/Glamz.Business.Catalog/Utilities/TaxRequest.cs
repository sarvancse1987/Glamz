using Glamz.Domain.Catalog;
using Glamz.Domain.Common;
using Glamz.Domain.Customers;

namespace Glamz.Business.Catalog.Utilities
{
    /// <summary>
    /// Represents a request for tax calculation
    /// </summary>
    public partial class TaxRequest
    {
        // <summary>
        /// Gets or sets a product
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets a customer
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets an address
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets a tax category identifier
        /// </summary>
        public string TaxCategoryId { get; set; }

        /// <summary>
        /// Gets or sets a price
        /// </summary>
        public double Price { get; set; }
    }
}
