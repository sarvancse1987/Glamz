using System.ComponentModel.DataAnnotations;

namespace Glamz.Api.DTOs.Catalog
{
    public partial class ProductCollectionDto
    {
        [Key]
        public string CollectionId { get; set; }
        public bool IsFeaturedProduct { get; set; }
    }
}
