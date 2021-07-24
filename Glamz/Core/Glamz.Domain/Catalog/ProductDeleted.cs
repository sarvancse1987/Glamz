using System;

namespace Glamz.Domain.Catalog
{
    public partial class ProductDeleted: Product
    {
        public DateTime DeletedOnUtc { get; set; }
    }
}
