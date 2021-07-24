using Glamz.Business.System.Utilities;
using Glamz.Domain.Catalog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glamz.Business.System.Interfaces.Reports
{
    /// <summary>
    /// Product report service interface
    /// </summary>
    public partial interface IProductsReportService
    {
        /// <summary>
        /// Get "low stock products" report
        /// </summary>
        /// <param name="vendorId">Vendor identifier</param>
        /// <param name="storeId">Store identifier</param>
        /// <returns>Result</returns>
        Task<(IList<Product> products, IList<ProductsAttributeCombination> combinations)> LowStockProducts(string vendorId, string storeId);
    }
}
