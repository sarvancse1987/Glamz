﻿using DotLiquid;
using Glamz.Domain.Messages;
using Glamz.Domain.Stores;
using System;
using System.Collections.Generic;

namespace Glamz.Business.Messages.DotLiquidDrops
{
    public partial class LiquidNewsLetterSubscription : Drop
    {
        private NewsLetterSubscription _subscription;
        private Store _store;
        public LiquidNewsLetterSubscription(NewsLetterSubscription subscription, Store store)
        {
            _subscription = subscription;
            _store = store;
            AdditionalTokens = new Dictionary<string, string>();
        }

        public string Email
        {
            get { return _subscription.Email; }
        }

        public string ActivationUrl
        {
            get
            {
                string urlFormat = "{0}/newsletter/subscriptionactivation/{1}/{2}";
                var activationUrl = String.Format(urlFormat, (_store.SslEnabled ? _store.SecureUrl.Trim('/') : _store.Url.Trim('/')), _subscription.NewsLetterSubscriptionGuid, "true");
                return activationUrl;
            }
        }

        public string DeactivationUrl
        {
            get
            {
                string urlFormat = "{0}/newsletter/subscriptionactivation/{1}/{2}";
                var deActivationUrl = String.Format(urlFormat, (_store.SslEnabled ? _store.SecureUrl.Trim('/') : _store.Url.Trim('/')), _subscription.NewsLetterSubscriptionGuid, "false");
                return deActivationUrl;
            }
        }

        public IDictionary<string, string> AdditionalTokens { get; set; }
    }
}