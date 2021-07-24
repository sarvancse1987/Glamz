using AutoMapper;
using Glamz.Api.DTOs.Catalog;
using Glamz.Domain.Catalog;
using Glamz.Infrastructure.Mapper;

namespace Glamz.Api.Infrastructure.Mapper
{
    public class SpecificationAttributeProfile : Profile, IAutoMapperProfile
    {
        public SpecificationAttributeProfile()
        {

            CreateMap<SpecificationAttributeDto, SpecificationAttribute>()
                .ForMember(dest => dest.UserFields, mo => mo.Ignore());

            CreateMap<SpecificationAttribute, SpecificationAttributeDto>();

            CreateMap<SpecificationAttributeOption, SpecificationAttributeOptionDto>();

            CreateMap<SpecificationAttributeOptionDto, SpecificationAttributeOption>()
                .ForMember(dest => dest.Locales, mo => mo.Ignore());

        }

        public int Order => 1;
    }
}
