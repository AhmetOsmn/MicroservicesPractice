namespace MicroservicesPractice.Services.Catalog.Dtos
{
    public class CourseUpdateDto
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public decimal Price { get; set; }
        public string UserId { get; set; } = null!;
        public string CategoryId { get; set; } = null!;
        public FeatureDto Feature { get; set; } = null!;
    }
}
