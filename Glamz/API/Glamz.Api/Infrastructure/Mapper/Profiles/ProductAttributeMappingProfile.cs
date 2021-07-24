using AutoMapper;
using Glamz.Api.DTOs.Catalog;
using Glamz.Domain.Catalog;
using Glamz.Infrastructure.Mapper;

namespace Glamz.Api.Infrastructure.Mapper
{
    public class ProductAttributeMappingProfile : Profile, IAutoMapperProfile
    {
        public ProductAttributeMappingProfile()
        {
            CreateMap<ProductAttributeMappingDto, ProductAttributeMapping>();
            CreateMap<ProductAttributeMapping, ProductAttributeMappingDto>();

            CreateMap<ProductAttributeValueDto, ProductAttributeValue>();
            CreateMap<ProductAttributeValue, ProductAttributeValueDto>();
        }

        public int Order => 1;
    }
}
