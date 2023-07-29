namespace MicroservicesPractice.Web.Models.Baskets
{
    public class BasketViewModel
    {
        public BasketViewModel()
        {
            _basketItems = new List<BasketItemViewModel>();
        }

        private List<BasketItemViewModel> _basketItems;
        
        public string? UserId { get; set; }
        
        public string? DiscountCode { get; set; }
        
        public List<BasketItemViewModel> BasketItems
        {
            get
            {
                if (HasDiscount)
                {
                    _basketItems.ForEach(x =>
                    {
                        var discountPrice = x.Price * ((decimal)DiscountRate.Value / 100);
                        x.AppliedDiscount(Math.Round(x.Price - discountPrice, 2));
                    });
                }

                return _basketItems;
            }

            set
            {
                _basketItems = value;
            }
        }

        public int? DiscountRate { get; set; }

        public decimal TotalPrice
        {
            get => _basketItems == null ? 0 : _basketItems.Sum(x => x.GetCurrentPrice);
        }

        public bool HasDiscount { get => !string.IsNullOrEmpty(DiscountCode) && DiscountRate.HasValue; }

        public void CancelDiscount()
        {
            DiscountCode = null;
            DiscountRate = null;
        }

        public void ApplyDiscount(string code, int rate)
        {
            DiscountCode = code;
            DiscountRate = rate;
        }
    }
}
