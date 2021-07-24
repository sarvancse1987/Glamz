using System.ComponentModel.DataAnnotations;

namespace Glamz.Api.Models
{
    public partial class BaseApiEntityModel
    {
        [Key]
        public string Id { get; set; }
    }
}
