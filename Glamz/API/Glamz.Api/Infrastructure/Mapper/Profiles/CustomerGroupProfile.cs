using AutoMapper;
using Glamz.Api.DTOs.Customers;
using Glamz.Domain.Customers;
using Glamz.Infrastructure.Mapper;

namespace Glamz.Api.Infrastructure.Mapper
{
    public class CustomerGroupProfile : Profile, IAutoMapperProfile
    {
        public CustomerGroupProfile()
        {

            CreateMap<CustomerGroupDto, CustomerGroup>()
                .ForMember(dest => dest.UserFields, mo => mo.Ignore());

            CreateMap<CustomerGroup, CustomerGroupDto>();

        }

        public int Order => 1;
    }
}
