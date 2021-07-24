using Glamz.Domain.Configuration;

namespace Glamz.Domain.Tax
{
    public class TaxProviderSettings : ISettings
    {
        public string ActiveTaxProviderSystemName { get; set; }
    }
}