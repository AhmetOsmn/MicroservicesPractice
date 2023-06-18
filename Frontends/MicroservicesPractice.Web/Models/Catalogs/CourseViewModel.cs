namespace MicroservicesPractice.Web.Models.Catalogs
{
    public class CourseViewModel
    {
        public string Id { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CategoryId { get; set; } = null!;
        public CategoryViewModel Category { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public FeatureViewModel Feature { get; set; } = null!;
    }
}
