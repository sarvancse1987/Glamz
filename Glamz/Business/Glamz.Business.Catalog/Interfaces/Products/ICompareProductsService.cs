using Glamz.Domain.Catalog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glamz.Business.Catalog.Interfaces.Products
{
    /// <summary>
    /// Compare products service interface
    /// </summary>
    public partial interface ICompareProductsService
    {
       
        /// <summary>
        /// Gets a "compare products" list
        /// </summary>
        /// <returns>"Compare products" list</returns>
        Task<IList<Product>> GetComparedProducts();

        /// <summary>
        /// Removes a product from a "compare products" list
        /// </summary>
        /// <param name="productId">Product identifier</param>
        void RemoveProductFromCompareList(string productId);

        /// <summary>
        /// Adds a product to a "compare products" list
        /// </summary>
        /// <param name="productId">Product identifier</param>
        void AddProductToCompareList(string productId);

        /// <summary>
        /// Clears a "compare products" list
        /// </summary>
        void ClearCompareProducts();

    }
}
