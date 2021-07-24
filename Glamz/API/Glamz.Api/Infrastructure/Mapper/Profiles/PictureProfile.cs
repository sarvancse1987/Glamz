using AutoMapper;
using Glamz.Api.DTOs.Common;
using Glamz.Domain.Media;
using Glamz.Infrastructure.Mapper;

namespace Glamz.Api.Infrastructure.Mapper
{
    public class PictureProfile : Profile, IAutoMapperProfile
    {
        public PictureProfile()
        {
            CreateMap<PictureDto, Picture>()
                .ForMember(dest => dest.UserFields, mo => mo.Ignore());

            CreateMap<Picture, PictureDto>()
                .ForMember(dest => dest.PictureBinary, mo => mo.Ignore());
        }

        public int Order => 1;
    }
}