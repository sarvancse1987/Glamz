using AutoMapper;
using Glamz.Api.DTOs.Customers;
using Glamz.Domain.Common;
using Glamz.Infrastructure.Mapper;

namespace Glamz.Api.Infrastructure.Mapper
{
    public class AddressProfile : Profile, IAutoMapperProfile
    {
        public AddressProfile()
        {
            CreateMap<AddressDto, Address>()
                .ForMember(dest => dest.Attributes, mo => mo.Ignore())
                .ForMember(dest => dest.UserFields, mo => mo.Ignore());

            CreateMap<Address, AddressDto>();
        }

        public int Order => 1;
    }
}
