using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MicroservicesPractice.Web.Models.Baskets
{
    public class BasketItemViewModel
    {
        private decimal? DiscountAppliedPrice;

        public int Quantity { get; set; } = 1;
        
        public decimal Price { get; set; }
        
        public string CourseId { get; set; } = null!;
       
        public string CourseName { get; set; } = null!;
        
        public decimal GetCurrentPrice { get => DiscountAppliedPrice != null ? DiscountAppliedPrice.Value : Price; }
        
        public void AppliedDiscount(decimal discountPrice)
        {
            DiscountAppliedPrice = discountPrice;
        }
    }
}
