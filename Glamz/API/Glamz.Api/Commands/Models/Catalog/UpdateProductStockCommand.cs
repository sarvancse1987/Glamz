using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class UpdateProductStockCommand : IRequest<bool>
    {
        public ProductDto Product { get; set; }
        public string WarehouseId { get; set; }
        public int Stock { get; set; }
    }
}
