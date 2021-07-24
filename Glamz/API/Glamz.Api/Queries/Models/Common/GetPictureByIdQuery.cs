using Glamz.Api.DTOs.Common;
using MediatR;

namespace Glamz.Api.Queries.Models.Common
{
    public class GetPictureByIdQuery : IRequest<PictureDto>
    {
        public string Id { get; set; }
    }
}
