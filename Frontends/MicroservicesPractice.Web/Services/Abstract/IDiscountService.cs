using MicroservicesPractice.Web.Models.Discount;

namespace MicroservicesPractice.Web.Services.Abstract
{
    public interface IDiscountService
    {
        Task<DiscountViewModel> GetDiscount(string discountCode);
    }
}
