using Glamz.Business.Catalog.Utilities;
using Glamz.Infrastructure.Plugins;
using System.Threading.Tasks;

namespace Glamz.Business.Catalog.Interfaces.Tax
{
    /// <summary>
    /// Provides an interface for creating tax providers
    /// </summary>
    public partial interface ITaxProvider : IProvider
    {
        /// <summary>
        /// Gets tax rate
        /// </summary>
        /// <param name="calculateTaxRequest">Tax calculation request</param>
        /// <returns>Tax</returns>
        Task<TaxResult> GetTaxRate(TaxRequest calculateTaxRequest);

    }
}
