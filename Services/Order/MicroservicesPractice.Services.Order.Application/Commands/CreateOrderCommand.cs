using MediatR;
using MicroservicesPractice.Services.Order.Application.Dtos;
using MicroservicesPractice.Shared.Dtos;

namespace MicroservicesPractice.Services.Order.Application.Commands
{
    public class CreateOrderCommand : IRequest<Response<CreatedOrderDto>>
    {
        public string BuyerId { get; set; } = null!;
        public List<OrderItemDto> OrderItems { get; set; } = null!;
        public AddressDto Address{ get; set; } = null!;
    }
}
