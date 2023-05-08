using MediatR;
using MicroservicesPractice.Services.Order.Application.Commands;
using MicroservicesPractice.Services.Order.Application.Dtos;
using MicroservicesPractice.Services.Order.Domain.OrderAggregate;
using MicroservicesPractice.Services.Order.Infrastructure;
using MicroservicesPractice.Shared.Dtos;

namespace MicroservicesPractice.Services.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>
    {
        private readonly OrderDbContext _context;

        public CreateOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Address newAddress = new(
                request.Address.Province,
                request.Address.District,
                request.Address.Street,
                request.Address.ZipCode,
                request.Address.Line);

            Domain.OrderAggregate.Order newOrder = new(request.BuyerId, newAddress);

            request.OrderItems.ForEach(x => newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl));

            await _context.SaveChangesAsync(cancellationToken);

            return Response<CreatedOrderDto>.Success(new CreatedOrderDto() { OrderId = newOrder.Id },200);
        }
    }
}
