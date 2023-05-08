using MicroservicesPractice.Services.Basket.Dtos;
using MicroservicesPractice.Shared.Dtos;

namespace MicroservicesPractice.Services.Basket.Services.Abstract
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> Delete(string userId);
    }
}
