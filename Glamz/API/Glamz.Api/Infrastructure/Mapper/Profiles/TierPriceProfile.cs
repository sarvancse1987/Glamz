using AutoMapper;
using Glamz.Api.DTOs.Catalog;
using Glamz.Domain.Catalog;
using Glamz.Infrastructure.Mapper;

namespace Glamz.Api.Infrastructure.Mapper
{
    public class TierPriceProfile : Profile, IAutoMapperProfile
    {
        public TierPriceProfile()
        {
            CreateMap<ProductTierPriceDto, TierPrice>();

            CreateMap<TierPrice, ProductTierPriceDto>();
        }

        public int Order => 1;
    }
}