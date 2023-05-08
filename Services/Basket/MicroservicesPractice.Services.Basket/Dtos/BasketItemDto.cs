namespace MicroservicesPractice.Services.Basket.Dtos
{
    public class BasketItemDto
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string CourseId { get; set; } = null!;
        public string CourseName { get; set; } = null!;
    }
}
