namespace MicroservicesPractice.Services.FakePayment.Models
{
    public class OrderDto
    {
        public OrderDto()
        {
            OrderItems = new();
        }
        public string BuyerId { get; set; } = null!;
        public List<OrderItemDto> OrderItems { get; set; }
        public AddressDto Address { get; set; } = null!;
    }

    public class OrderItemDto
    {
        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string PictureUrl { get; set; } = null!;
        public decimal Price { get; set; }
    }

    public class AddressDto
    {
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? Street { get; set; }
        public string? ZipCode { get; set; }
        public string? Line { get; set; }
    }

}
