using Glamz.Domain.Configuration;

namespace Glamz.Domain.Documents
{
    public class DocumentSettings : ISettings
    {
        /// <summary>
        /// Gets or sets the page size for documents
        /// </summary>
        public int PageSize { get; set; } = 10;
    }
}
