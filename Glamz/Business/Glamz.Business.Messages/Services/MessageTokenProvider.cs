﻿using Glamz.Business.Messages.Interfaces;
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
using Glamz.Business.Messages.DotLiquidDrops;
using MediatR;
using System.Threading.Tasks;
using Glamz.Business.Messages.Commands.Models;
using Glamz.Business.Messages.Extensions;

namespace Glamz.Business.Messages.Services
{
    public partial class MessageTokenProvider : IMessageTokenProvider
    {
    
        #region Methods

        /// <summary>
        /// Gets list of allowed (supported) message tokens for campaigns
        /// </summary>
        /// <returns>List of allowed (supported) message tokens for campaigns</returns>
        public virtual string[] GetListOfCampaignAllowedTokens()
        {
            var allowedTokens = LiquidExtensions.GetTokens(typeof(LiquidStore),
                typeof(LiquidNewsLetterSubscription),
                typeof(LiquidShoppingCart),
                typeof(LiquidCustomer));

            return allowedTokens.ToArray();
        }

        public virtual string[] GetListOfAllowedTokens()
        {
            var allowedTokens = LiquidExtensions.GetTokens(
                typeof(LiquidAskQuestion),
                typeof(LiquidAttributeCombination),
                typeof(LiquidAuctions),
                typeof(LiquidOutOfStockSubscription),
                typeof(LiquidBlogComment),
                typeof(LiquidContactUs),
                typeof(LiquidCustomer),
                typeof(LiquidEmailAFriend),
                typeof(LiquidGiftVoucher),
                typeof(LiquidKnowledgebase),
                typeof(LiquidNewsComment),
                typeof(LiquidNewsLetterSubscription),
                typeof(LiquidOrder),
                typeof(LiquidOrderItem),
                typeof(LiquidProduct),
                typeof(LiquidProductReview),
                typeof(LiquidMerchandiseReturn),
                typeof(LiquidShipment),
                typeof(LiquidShipmentItem),
                typeof(LiquidShoppingCart),
                typeof(LiquidStore),
                typeof(LiquidVatValidationResult),
                typeof(LiquidVendor),
                typeof(LiquidVendorReview));

            return allowedTokens.ToArray();
        }

        public virtual string[] GetListOfCustomerReminderAllowedTokens(CustomerReminderRuleEnum rule)
        {
            var allowedTokens = LiquidExtensions.GetTokens(typeof(LiquidStore));

            if (rule == CustomerReminderRuleEnum.AbandonedCart)
            {
                allowedTokens.AddRange(LiquidExtensions.GetTokens(typeof(LiquidShoppingCart)));
            }

            if (rule == CustomerReminderRuleEnum.CompletedOrder || rule == CustomerReminderRuleEnum.UnpaidOrder)
            {
                allowedTokens.AddRange(LiquidExtensions.GetTokens(typeof(LiquidOrder)));
            }

            allowedTokens.AddRange(LiquidExtensions.GetTokens(typeof(LiquidCustomer)));

            return allowedTokens.ToArray();
        }

        #endregion
    }
}