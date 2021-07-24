using DotLiquid;
using Glamz.Business.Common.Extensions;
using Glamz.Domain.Knowledgebase;
using Glamz.Domain.Localization;
using Glamz.Domain.Stores;
using System.Collections.Generic;

namespace Glamz.Business.Messages.DotLiquidDrops
{
    public partial class LiquidKnowledgebase : Drop
    {
        private KnowledgebaseArticle _article;
        private KnowledgebaseArticleComment _articleComment;
        private Store _store;
        private Language _language;

        public LiquidKnowledgebase(KnowledgebaseArticle article, KnowledgebaseArticleComment articleComment, Store store, Language language)
        {
            _article = article;
            _articleComment = articleComment;
            _store = store;
            _language = language;
            AdditionalTokens = new Dictionary<string, string>();
        }

        public string ArticleCommentTitle
        {
            get { return _article.Name; }
        }

        public string ArticleCommentUrl
        {
            get
            {
                return $"{(_store.SslEnabled ? _store.SecureUrl.Trim('/') : _store.Url.Trim('/'))}/{_article.GetSeName(_language.Id)}";
            }
        }

        public IDictionary<string, string> AdditionalTokens { get; set; }
    }
}