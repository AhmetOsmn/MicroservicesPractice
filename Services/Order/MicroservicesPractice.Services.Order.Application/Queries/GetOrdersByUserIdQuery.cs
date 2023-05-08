using MediatR;
using MicroservicesPractice.Services.Order.Application.Dtos;
using MicroservicesPractice.Shared.Dtos;

namespace MicroservicesPractice.Services.Order.Application.Queries
{
    public class GetOrdersByUserIdQuery : IRequest<Response<List<OrderDto>>>
    {
        public string UserId { get; set; } = null!;
    }
}
