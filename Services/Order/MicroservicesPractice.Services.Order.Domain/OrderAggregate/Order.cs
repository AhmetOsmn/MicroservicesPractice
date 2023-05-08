using MicroservicesPractice.Services.Order.Domain.Core;

namespace MicroservicesPractice.Services.Order.Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public DateTime CreatedDate { get; }
        public Address Address { get; }
        public string BuyerId { get; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order(string buyerId, Address address)
        {
            Address = address;
            BuyerId = buyerId;
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
        }

        public Order() { }

        public void AddOrderItem(string productId, string productName, decimal price, string pictureUrl)
        {
            bool existProduct = _orderItems.Any(x => x.ProductId == productId);

            if (!existProduct)
            {
                OrderItem newOrderItem = new(productId, productName, pictureUrl, price);
                _orderItems.Add(newOrderItem);
            }
        }

        public decimal GetTotalPrice => _orderItems.Sum(x => x.Price);
    }
}
