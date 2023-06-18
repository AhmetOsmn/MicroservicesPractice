namespace MicroservicesPractice.Web.Models.Catalogs
{
    public class CourseCreateInput
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public decimal Price { get; set; }
        public string UserId { get; set; } = null!;
        public string CategoryId { get; set; } = null!;
        public FeatureViewModel Feature { get; set; } = null!;
    }
}
