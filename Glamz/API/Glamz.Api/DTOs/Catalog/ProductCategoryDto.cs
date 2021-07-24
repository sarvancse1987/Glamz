using System.ComponentModel.DataAnnotations;

namespace Glamz.Api.DTOs.Catalog
{
    public partial class ProductCategoryDto
    {
        [Key]
        public string CategoryId { get; set; }
        public bool IsFeaturedProduct { get; set; }
    }
}
