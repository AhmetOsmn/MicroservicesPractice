namespace MicroservicesPractice.Services.Discount.Models
{
    [Dapper.Contrib.Extensions.Table("discount")]
    public class Discount
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public string UserId { get; set; } = null!;
        public string Code { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
    }
}
