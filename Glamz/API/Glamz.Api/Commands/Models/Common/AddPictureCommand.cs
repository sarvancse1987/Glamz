using Glamz.Api.DTOs.Common;
using MediatR;

namespace Glamz.Api.Commands.Models.Common
{
    public class AddPictureCommand : IRequest<PictureDto>
    {
        public PictureDto PictureDto { get; set; }
    }
}
