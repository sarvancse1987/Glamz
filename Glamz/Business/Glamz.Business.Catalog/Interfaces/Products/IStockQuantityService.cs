using Glamz.Domain.Catalog;
using Glamz.Domain.Common;
using System.Collections.Generic;

namespace Glamz.Business.Catalog.Interfaces.Products
{
    public interface IStockQuantityService
    {
        int GetTotalStockQuantity(Product product,
            bool useReservedQuantity = true,
            string warehouseId = "", bool total = false);

        int GetTotalStockQuantityForCombination(Product product, ProductAttributeCombination combination,
            bool useReservedQuantity = true, string warehouseId = "");

        string FormatStockMessage(Product product, string warehouseId, IList<CustomAttribute> attributes);
    }
}
