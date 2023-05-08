namespace MicroservicesPractice.Services.Basket.Dtos
{
    public class BasketDto
    {
        public string UserId { get; set; } = null!;
        public string DiscountCode { get; set; } = null!;
        public List<BasketItemDto>? BasketItems { get; set; }

        public decimal TotalPrice
        {
            get => BasketItems == null ? 0 : BasketItems.Sum(x => x.Price * x.Quantity);
        }
    }
}
