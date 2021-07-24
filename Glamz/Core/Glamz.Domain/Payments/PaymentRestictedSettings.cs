using Glamz.Domain.Configuration;
using System.Collections.Generic;

namespace Glamz.Domain.Payments
{
    public class PaymentRestictedSettings : ISettings
    {
        public PaymentRestictedSettings()
        {
            Ids = new List<string>();
        }
        public IList<string> Ids { get; set; }
    }
}
