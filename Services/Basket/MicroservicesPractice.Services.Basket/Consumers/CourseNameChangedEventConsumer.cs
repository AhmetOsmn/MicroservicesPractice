using MassTransit;
using MicroservicesPractice.Services.Basket.Services.Abstract;
using MicroservicesPractice.Shared.Messages;

namespace MicroservicesPractice.Services.Basket.Consumers
{
    public class CourseNameChangedEventConsumer : IConsumer<CourseNameChangedEvent>
    {
        private readonly IBasketService _basketService;
        public CourseNameChangedEventConsumer(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task Consume(ConsumeContext<CourseNameChangedEvent> context)
        {
            await _basketService.UpdateCourseNames(context.Message.CourseId, context.Message.UpdatedName);
        }
    }
}
