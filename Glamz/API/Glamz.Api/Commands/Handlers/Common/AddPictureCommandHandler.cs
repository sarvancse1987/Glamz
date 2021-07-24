using Glamz.Api.Commands.Models.Common;
using Glamz.Api.DTOs.Common;
using Glamz.Api.Extensions;
using Glamz.Business.Storage.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Commands.Handlers.Common
{
    public class AddPictureCommandHandler : IRequestHandler<AddPictureCommand, PictureDto>
    {
        private readonly IPictureService _pictureService;

        public AddPictureCommandHandler(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        public async Task<PictureDto> Handle(AddPictureCommand request, CancellationToken cancellationToken)
        {
            var picture = await _pictureService.InsertPicture(request.PictureDto.PictureBinary, request.PictureDto.MimeType,
                request.PictureDto.SeoFilename,
                request.PictureDto.AltAttribute,
                request.PictureDto.TitleAttribute,
                request.PictureDto.IsNew,
                request.PictureDto.Reference,
                request.PictureDto.ObjectId);

            return picture.ToModel();

        }
    }
}
