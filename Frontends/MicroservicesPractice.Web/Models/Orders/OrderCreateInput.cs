namespace MicroservicesPractice.Web.Models.Orders
{
    public class OrderCreateInput
    {
        public OrderCreateInput()
        {
            OrderItems = new();
        }
        public string BuyerId { get; set; } = null!;
        public List<OrderItemCreateInput> OrderItems { get; set; }
        public AddressCreateInput Address { get; set; } = null!;
    }
}
