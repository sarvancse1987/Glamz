using Glamz.Domain.Catalog;
using Glamz.Domain.Customers;
using Glamz.Domain.Discounts;
using Glamz.Infrastructure.Plugins;
using System.Threading.Tasks;

namespace Glamz.Business.Catalog.Interfaces.Discounts
{
    public partial interface IDiscountAmountProvider : IProvider
    {
        Task<double> DiscountAmount(Discount discount, Customer customer, Product product, double amount);
    }
}
