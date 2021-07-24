using Glamz.Api.DTOs.Common;
using MediatR;

namespace Glamz.Api.Commands.Models.Common
{
    public class DeletePictureCommand : IRequest<bool>
    {
        public PictureDto PictureDto { get; set; }
    }
}
