using AutoMapper;
using MicroservicesPractice.Services.Order.Application.Dtos;
using MicroservicesPractice.Services.Order.Domain.OrderAggregate;

namespace MicroservicesPractice.Services.Order.Application.Mapping
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Domain.OrderAggregate.Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
