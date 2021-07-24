using Glamz.Infrastructure.Plugins;
using System.Collections.Generic;

namespace Glamz.Business.Catalog.Interfaces.Discounts
{
    public partial interface IDiscountProvider : IProvider
    {
        IList<IDiscountRule> GetRequirementRules();
    }
}
