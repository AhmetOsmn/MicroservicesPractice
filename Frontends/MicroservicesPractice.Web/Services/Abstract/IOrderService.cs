using MicroservicesPractice.Web.Models.Orders;

namespace MicroservicesPractice.Web.Services.Abstract
{
    public interface IOrderService
    {
        // sync
        Task<OrderCreatedViewModel?> CreateOrder(CheckoutInfoInput checkoutInfoInput);

        // async
        Task<OrderSuspendViewModel> SuspendOrder(CheckoutInfoInput checkoutInfoInput);
        
        Task<List<OrderViewModel>> GetOrder();
    }
}
