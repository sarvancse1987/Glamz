using DotLiquid;
using Glamz.Business.Common.Extensions;
using Glamz.Domain.Catalog;
using Glamz.Domain.Localization;
using Glamz.Domain.Stores;
using System.Collections.Generic;

namespace Glamz.Business.Messages.DotLiquidDrops
{
    public partial class LiquidOutOfStockSubscription : Drop
    {
        private readonly OutOfStockSubscription _outOfStockSubscription;
        private readonly Product _product;
        private readonly Store _store;
        private readonly Language _language;

        public LiquidOutOfStockSubscription(Product product, OutOfStockSubscription outOfStockSubscription, Store store, Language language)
        {
            _outOfStockSubscription = outOfStockSubscription;
            _product = product;
            _store = store;
            _language = language;

            AdditionalTokens = new Dictionary<string, string>();
        }

        public string ProductName
        {
            get { return _product.Name; }
        }

        public string AttributeInfo
        {
            get { return _outOfStockSubscription.AttributeInfo; }
        }

        public string ProductUrl
        {
            get { return string.Format("{0}/{1}", _store.SslEnabled ? _store.SecureUrl.Trim('/') : _store.Url.Trim('/'), _product.GetSeName(_language.Id)); }
        }

        public IDictionary<string, string> AdditionalTokens { get; set; }
    }
}