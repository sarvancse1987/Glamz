using Glamz.Domain.Blogs;
using Glamz.Domain.Catalog;
using Glamz.Domain.Customers;
using Glamz.Domain.Knowledgebase;
using Glamz.Domain.Localization;
using Glamz.Domain.Messages;
using Glamz.Domain.News;
using Glamz.Domain.Orders;
using Glamz.Domain.Shipping;
using Glamz.Domain.Stores;
using Glamz.Domain.Vendors;
using System.Threading.Tasks;

namespace Glamz.Business.Messages.Interfaces
{
    public partial interface IMessageTokenProvider
    {
        string[] GetListOfCampaignAllowedTokens();
        string[] GetListOfAllowedTokens();
        string[] GetListOfCustomerReminderAllowedTokens(CustomerReminderRuleEnum rule);
    }
}