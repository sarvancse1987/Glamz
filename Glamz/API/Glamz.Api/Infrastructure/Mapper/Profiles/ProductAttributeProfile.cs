using AutoMapper;
using Glamz.Api.DTOs.Catalog;
using Glamz.Domain.Catalog;
using Glamz.Infrastructure.Mapper;

namespace Glamz.Api.Infrastructure.Mapper
{
    public class ProductAttributeProfile : Profile, IAutoMapperProfile
    {
        public ProductAttributeProfile()
        {

            CreateMap<ProductAttributeDto, ProductAttribute>()
                .ForMember(dest => dest.UserFields, mo => mo.Ignore());

            CreateMap<ProductAttribute, ProductAttributeDto>();

            CreateMap<PredefinedProductAttributeValue, PredefinedProductAttributeValueDto>();

            CreateMap<PredefinedProductAttributeValueDto, PredefinedProductAttributeValue>()
                .ForMember(dest => dest.Locales, mo => mo.Ignore());

        }

        public int Order => 1;
    }
}
