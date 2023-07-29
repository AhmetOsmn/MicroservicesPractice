namespace MicroservicesPractice.Web.Models.Orders
{
    public class OrderCreatedViewModel
    {
        public int OrderId { get; set; }

        public string? ErrorMessage { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
