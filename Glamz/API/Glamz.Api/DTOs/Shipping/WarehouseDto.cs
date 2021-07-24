using Glamz.Api.Models;

namespace Glamz.Api.DTOs.Shipping
{
    public partial class WarehouseDto : BaseApiEntityModel
    {
        public string Name { get; set; }
        public string AdminComment { get; set; }
    }
}
