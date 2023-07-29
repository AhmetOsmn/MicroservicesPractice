using MicroservicesPractice.Services.Basket.Dtos;
using MicroservicesPractice.Services.Basket.Services.Abstract;
using MicroservicesPractice.Shared.Dtos;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using StackExchange.Redis;
using System.Text.Json;

namespace MicroservicesPractice.Services.Basket.Services.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> Delete(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);

            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket not found", 404);
        }

        public async Task UpdateCourseNames(string courseId, string updatedCourseName)
        {           
            List<string> keysList = await _redisService.GetKeysAsync("*");

            if (keysList.Any())
            {
                await Task.WhenAll(keysList.Select(async item =>
                {
                    var result = await GetBasket(item);

                    if (result.IsSuccessful)
                    {
                        var basket = result.Data;
                        var basketItems = basket.BasketItems.Where(x => x.CourseId == courseId).ToList();
                        basketItems.ForEach(x =>
                        {
                            x.CourseName = updatedCourseName;
                        });

                        await SaveOrUpdate(basket);
                    }
                }));
            }
        }

        public async Task<Response<BasketDto>> GetBasket(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);

            if (string.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDto>.Fail("Basket not found", 404);
            }

            var basketDto = JsonSerializer.Deserialize<BasketDto>(existBasket!);

            return basketDto == null ? throw new InvalidOperationException("basketDto is null") : Response<BasketDto>.Success(basketDto, 200);
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));

            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket could not update or save", 500);
        }
    }
}
